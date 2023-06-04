using FastRouting.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using FastRouting.Repositories.Entities;
using FastRouting.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Xml.Linq;
using System;
using System.Collections.Generic;
using FastRouting.Services.Interfaces.ILogic;
using AutoMapper;
using FastRouting.Services.Interfaces;
using Newtonsoft.Json.Linq;
using System.Collections;

namespace FastRouting.Services.Services.Logic
{
    //קלאס זה מכיל את הקשתות המקוריות + תרגום מזהי המיקומים לאינדקס שלהם בגרף


    //קלאס זה מבטא קשת של גרף
    public class EdgeOfGraph
    {
        //האינדקס בגרף שבו נמצא קודקוד  ראשון של הקשת
        public int indexA { get; set; }
        //האינדקס בגרף שבו נמצא קודקוד שני של הקשת
        public int indexB { get; set; }
        //אובייקט הקשת המקורי
        public EdgesDTO edge { get; set; }
        public EdgeOfGraph(EdgesDTO edge)
        {
            this.edge = edge;
        }
    }
    //ליסט של אוביקטי "קומה", יוחזר בסופו של דבר ללקוח
    public class Floor
    {
        //ליסט של קודקודים המרכיבים את קטע המסלול בקומה מסוימת
        public List<VertexOfGraph> vertexsOfFloor  { get; set; }
        //ליסט של משפטי הכוון למשתמש איך לצעוד בקומה מסוימת
        public List<string> directions { get; set; }
        //ליסט של תמונות הקשורות לקומה מסוימת
        public List<TheCenterPhotoDTO> TheCenterPhotoDTO  { get; set; }

        public Floor()
        {
            this.vertexsOfFloor = new List<VertexOfGraph>();
            this.directions = new List<string>();
            this.TheCenterPhotoDTO= new List<TheCenterPhotoDTO>();
        }
        public Floor(List<VertexOfGraph> vertexsOfFloor, List<string> directions, List<TheCenterPhotoDTO> TheCenterPhotoDTO)
        {
            this.TheCenterPhotoDTO = TheCenterPhotoDTO;
            this.directions=directions;
            this.vertexsOfFloor=vertexsOfFloor;
            
        }
    }


    //קלאס זה מבטא קודקוד בגרף
    //הנקודות בו יכולות להיות מסוג מיקומים או מסוג הצטלבויות
    public class VertexOfGraph
    {
        //public int num { get; set; }
        //private int vertexNum;
        public CoordinateDTO coordinate { get; set; }
        public LocationTypesDTO locationTypes { get; set; }
        public string name { get; set; }
        public int trasition { get; set; }
        //האם זו הצטלבות שיש גם מיקום באותה קאורדיננטה?
        public bool  IntersectionOnLocation { get; set; }
        //כל הקודקודים השכנים לקודקוד מסוים
        public List<EdgeOfGraph> edgesOfGraphs { get; set; }
        //בנאי למקרה שהנקודה היא נקודת מיקום
        public VertexOfGraph(CoordinateDTO coordinate, LocationTypesDTO LocationTypes, string name/*, int num*/, int trasition)
        {
            this.coordinate = coordinate;
            this.locationTypes = LocationTypes;
            this.name = name;
            edgesOfGraphs = new List<EdgeOfGraph>();
            this.trasition = trasition;
            this.IntersectionOnLocation= false;
        }
        //בנאי למקרה שהנקודה היא נקודת הצטלבות
        public VertexOfGraph(CoordinateDTO coordinate, bool intersectionOnLocation)
        {
            // this.num = num;
            this.coordinate = coordinate;
            this.IntersectionOnLocation = intersectionOnLocation;
            locationTypes = null;
            name = null;
            
            edgesOfGraphs = new List<EdgeOfGraph>();

        }
    }
    //קלאס 
    public class AdjListNode : IComparable<AdjListNode>
    {
        public static bool flag;
        private int vertex;
        private double weight;
        public AdjListNode(int v, double w)
        {
            vertex = v;
            weight = w;
        }
        public int getVertex() { return vertex; }
        public void setVertex(int v) { vertex = v; }
        public double getWeight() { return weight; }
        public void setWeight(double v) { weight = v; }
        public int CompareTo(AdjListNode other)
        {
            double ans = weight - other.weight;
            if (ans < 0)
            {
                return -1;
            }
            if (ans > 0)
            {
                return 1;
            }
            else
            {
             flag= false;
             return 0;
            }
            
        }
    }


   

public  class RouteCalculation: IRouteCalculation
    {
        private readonly ICentersService _Centerservice;
        private readonly ILocationsService _locationsService;
        private readonly IIntersectionsService _IntersectionsService;
        private readonly ITheCenterPhotoService _TheCenterPhotoService;
        private readonly IMapper _mapper;
        private readonly IEdgesService _edgesService;
        private readonly ITransitionsService _transitionsService;
        private readonly ILocationTypesService _locationTypesService;
        private readonly ITransitionsToIntersectionsService _transitionsToIntersectionsService;
        public RouteCalculation(IMapper mapper, ICentersService Centerservice, IEdgesService edgesService, ITheCenterPhotoService TheCenterPhotoService, IIntersectionsService intersectionsService, ILocationsService locationsService, ITransitionsService transitionsService, ILocationTypesService locationTypesService, ITransitionsToIntersectionsService transitionsToIntersectionsService)
        {
            _mapper = mapper;
            _Centerservice = Centerservice;
            _edgesService = edgesService;
            _TheCenterPhotoService = TheCenterPhotoService;
            _IntersectionsService = intersectionsService;
            _locationsService = locationsService;
            _transitionsService = transitionsService;
            _locationTypesService = locationTypesService;
            _transitionsToIntersectionsService = transitionsToIntersectionsService;
        }
        public  async Task<List<Floor>> MainFunction(string nameSource,string nameDestination,int idCenter)
        {
            List<Floor> vertexOfGraphs = new List<Floor>();
            List<LocationsDTO> locations = new List<LocationsDTO>();
            List<IntersectionsDTO> intersections = new List<IntersectionsDTO>();
            List<EdgesDTO> edges = new List<EdgesDTO>();
            locations= await _locationsService.GetByCenterIdAsync(idCenter);
            intersections=await _IntersectionsService.GetBycenterIdAsync(idCenter);
            edges=await _edgesService.GetByCenterIdAsync(idCenter);
            vertexOfGraphs= await PreparingTheGraph(locations, intersections, edges,nameSource,nameDestination);
            return vertexOfGraphs;

        }


        public async Task<List<Floor>> PreparingTheGraph(List<LocationsDTO> locations, List<IntersectionsDTO> intersections, List<EdgesDTO> edges, string nameSource, string nameDestination)
        {
            int src=0;
            int dest=0;
            int index = 0;
            VertexOfGraph[] graph = new VertexOfGraph[locations.Count + intersections.Count];
            List<EdgeOfGraph> listEdgeOfGraph = new List<EdgeOfGraph>();
            //מעבר על כל הקשתות והפיכתן ל "קשתות של גרף"
            foreach (var edge in edges)
            {
                EdgeOfGraph edgeOfGraph = new EdgeOfGraph(edge);
                listEdgeOfGraph.Add(edgeOfGraph);
            }


            foreach (var location in locations)
            {
                if(location.locationName== nameSource)
                {
                    src= index;
                }
                if(location.locationName== nameDestination)
                {
                    dest= index;
                }

                foreach (var edgeOfGraph in listEdgeOfGraph)
                {
                    if (location.coordinate.coordinateId == edgeOfGraph.edge.locationIdA)
                    {
                        edgeOfGraph.indexA = index;
                    }
                    else
                    {
                        if (location.coordinate.coordinateId == edgeOfGraph.edge.locationIdB)
                        {

                            edgeOfGraph.indexB = index;
                        }
                    }


                }

                VertexOfGraph VertexOfGraph = new VertexOfGraph(location.coordinate, location.locationTypes, location.locationName/*, index*/,location.transitionId);

                graph[index] = VertexOfGraph;
                index++;

            }

            foreach (var intersection in intersections)
            {
                //List<EdgeOfGraph> listEdgeOfGraph = new List<EdgeOfGraph>();

                foreach (var edgeOfGraph in listEdgeOfGraph)
                {
                    if (intersection.coordinate.coordinateId == edgeOfGraph.edge.locationIdA)
                    {
                        edgeOfGraph.indexA = index;
                    }
                    else
                    {
                        if (intersection.coordinate.coordinateId == edgeOfGraph.edge.locationIdB)
                        {

                            edgeOfGraph.indexB = index;
                        }
                    }


                }

                VertexOfGraph VertexOfGraph = new VertexOfGraph(intersection.coordinate,intersection.IntersectionOnLocation);

                graph[index] = VertexOfGraph;
                index++;

            }
            foreach (var egdeOfGraph in listEdgeOfGraph)
            {
                graph[egdeOfGraph.indexA].edgesOfGraphs.Add(egdeOfGraph);
            }


            List<Floor> vertexOfGraphs;
            vertexOfGraphs=await DijkstraAlgorithm(src, dest, graph, locations[0].centerId);
            return vertexOfGraphs;
        }

        //חשוב מאד!!
        //המקור והיעד הם האינדקסים של המקומות בגרף המבטאים מקור ויעד
        public async Task<List<Floor>> DijkstraAlgorithm(int src, int dest, VertexOfGraph[] graph,int centerId)
        {
            const double epsilon = 0.001;
            List<VertexOfGraph> VertexOfGraph = new List<VertexOfGraph>();
            double[] distance = new double[graph.Length];
            int[] parent = new int[graph.Length];

            for (int i = 0; i < graph.Length; i++)
            {
                distance[i] = double.MaxValue;
                parent[i] = -1;
            }

            distance[src] = 0;
            SortedSet<AdjListNode> pq = new SortedSet<AdjListNode>();
            pq.Add(new AdjListNode(src, 0));

            while (pq.Count > 0)
            {

                AdjListNode current = pq.First();
                if (current.getVertex() == dest)
                {
                    break;
                }
                pq.Remove(current);

                foreach (EdgeOfGraph n in graph[current.getVertex()].edgesOfGraphs)
                {

                    if ((distance[current.getVertex()] + n.edge.distance < distance[n.indexB])/*||(((distance[current.getVertex()] + n.Edge.Distance) == distance[n.IndexB])&&(graph[current.getVertex()].name!=null))*/)
                    {
                        distance[n.indexB] = distance[current.getVertex()] + n.edge.distance;
                        parent[n.indexB] = current.getVertex();
                        AdjListNode a = new AdjListNode(
                        n.indexB,
                        distance[n.indexB]);
                        AdjListNode.flag = true;
                        bool containsWeight = pq.Any(adjListNode => adjListNode.getWeight() == a.getWeight());
                        while(containsWeight)
                        {
                            a.setWeight(a.getWeight()+epsilon);
                            containsWeight = pq.Any(adjListNode => adjListNode.getWeight() == a.getWeight());
                        }
                        //if(containsWeight5 )
                        //{
                        //    a.setWeight(a.getWeight()+epsilon);
                        //}
                        pq.Add(a);
                        //while (AdjListNode.flag==false)
                        //{
                            
                        //    pq.Add(a);
                        //}
                       
                    }
                }
            }
            int currentVertexOfGraph = dest;
            while (currentVertexOfGraph != src)
            {
                graph[currentVertexOfGraph].edgesOfGraphs = null;
                VertexOfGraph.Insert(0, graph[currentVertexOfGraph]);
                currentVertexOfGraph = parent[currentVertexOfGraph];
            }
            graph[src].edgesOfGraphs = null;
            VertexOfGraph.Insert(0, graph[src]);

            for (int i = 0; i < (VertexOfGraph.Count)-1; i++)
            {
                if (VertexOfGraph[i].coordinate.x==VertexOfGraph[i+1].coordinate.x&&
                    VertexOfGraph[i].coordinate.y==VertexOfGraph[i+1].coordinate.y&&
                    VertexOfGraph[i].coordinate.z==VertexOfGraph[i+1].coordinate.z)
                {
                    if (VertexOfGraph[i].name!=null)
                    {
                        VertexOfGraph.RemoveAt(i+1);
                    }
                    else
                    {
                        VertexOfGraph.RemoveAt(i);
                    }
                    i++;
                }
            }


            List<LocationsDTO> locations;
            LocationsDTO foundLocation;
            locations=await _locationsService.GetByCenterIdAsync(centerId);
            foreach (VertexOfGraph vertex in VertexOfGraph)
            {
                if (vertex.name==null&&vertex.IntersectionOnLocation==true)
                {
                    foundLocation = locations.Find(obj => obj.coordinate.x== vertex.coordinate.x
                    && obj.coordinate.y == vertex.coordinate.y
                    && obj.coordinate.z == vertex.coordinate.z&&obj.locationName!=null);
                    if (foundLocation!=null)
                    {
                        vertex.name=foundLocation.locationName;
                    }

                }
            }


            return await  GetRoute(VertexOfGraph, centerId);
        }

        
        public async Task<string> GetDirection(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            double angle1 = Math.Atan2(y2 - y1, x2 - x1) * 180 / Math.PI;
            double angle2 = Math.Atan2(y3 - y2, x3 - x2) * 180 / Math.PI;
            double angle = angle2 - angle1;
            if (angle < -180) angle += 360;
            if (angle > 180) angle -= 360;
            if (angle < -30) return "פנה שמאלה ל ";
            if (angle > 30) return "פנה ימינה ל";
            return "המשך ישר ל";
        } 

        public async Task<List<Floor>> GetRoute(List<VertexOfGraph> vertexsOfGraph,int centerId)
        {
            Floor floor;
            List<Floor> floors = new List<Floor>();
            List<string> directions=new List<string>();
            List<VertexOfGraph> vertexsOfFloor=new List<VertexOfGraph>();
            List<TheCenterPhotoDTO> TheCenterPhoto=new List<TheCenterPhotoDTO>();
            double xPrev;
            double yPrev;
            double xCurrent;
            double yCurrent;
            double xNext;
            double yNext;
            string locationName="";
            string currentDirection;
            int trasition;
            Task<string> partOfTheDirection;
            string result;
            int index = 0;
            int numOfVertexsInT = 0;
            int listLength = vertexsOfGraph.Count;
            int z= vertexsOfGraph[index].coordinate.z;
            bool flag = true;
            //כל סיבוב לולאה בלולאה החיצונית, מבטא אובייקט "קומה" חדש
            while (index<listLength)
            {
                numOfVertexsInT=0;
                z = vertexsOfGraph[index].coordinate.z;
                xPrev= vertexsOfGraph[index].coordinate.x;
                yPrev= vertexsOfGraph[index].coordinate.y;
                numOfVertexsInT++;
                vertexsOfFloor.Add(vertexsOfGraph[index]);
                trasition = vertexsOfGraph[index].trasition;
                index++;
                //טיפול נפרד במעבר הראשון בקומה, בו כיוון ההדרכה נמדד אחרת
                while (index<listLength&&z==vertexsOfGraph[index].coordinate.z
                    &&(trasition==vertexsOfGraph[index].trasition))
                {
                    numOfVertexsInT++;
                    vertexsOfFloor.Add(vertexsOfGraph[index]);
                    if (vertexsOfGraph[index].name != null)
                    {
                      locationName= vertexsOfGraph[index].name;
                    }
                    index++;
                }
               
                // או שנגמר הליסט בודקת למה יצאנו מהלולאה, האם הגענו להצטלבות או למיקום
                if (index==listLength)
                {
                    directions.Add("המשך ישר עד "+locationName);
                }
                else
                {
                    if (z!=vertexsOfGraph[index].coordinate.z)
                    {
                        if(numOfVertexsInT>1)
                        {
                            directions.Add("המשך לכוון"+locationName);
                        }
                        directions.Add("המשך לקומה "+vertexsOfGraph[index].coordinate.z);
                    }
                    else
                    {
                        if (vertexsOfGraph[index].name==null)
                        {
                            if (numOfVertexsInT>1)
                            {
                                directions.Add("המשך עד "+locationName);

                            }
                            directions.Add("המשך מעט ");
                            vertexsOfFloor.Add(vertexsOfFloor[index]);
                            index++;
                            while (index<listLength&& vertexsOfGraph[index].name==null)
                            {
                                vertexsOfFloor.Add(vertexsOfGraph[index]);
                                index++;
                                directions.Add("המשך עוד");
                            }
                        }
                        else
                        {
                            directions.Add("המשך לכוון "+vertexsOfGraph[index].name);
                        }
                        xCurrent =vertexsOfGraph[index].coordinate.x;
                        yCurrent=vertexsOfGraph[index].coordinate.y;

                        //המשך טיפול בשאר הקודקודים הנמצאים בקומה זו
                        while (index<listLength&&z==vertexsOfGraph[index].coordinate.z)
                        {
                            numOfVertexsInT=0;
                            trasition =vertexsOfGraph[index].trasition;
                            while (index<listLength&&z==vertexsOfGraph[index].coordinate.z
                                &&trasition==vertexsOfGraph[index].trasition)
                            {
                                numOfVertexsInT++;
                                vertexsOfFloor.Add(vertexsOfGraph[index]);
                                if (vertexsOfGraph[index].name != null)
                                {
                                    locationName= vertexsOfGraph[index].name;
                                }
                                index++;
                            }
                            if (index==listLength)
                            {
                                if(numOfVertexsInT>1)
                                {
                                    xNext =vertexsOfGraph[index-1].coordinate.x;
                                    yNext=vertexsOfGraph[index-1].coordinate.y;
                                    partOfTheDirection=GetDirection(xPrev, yPrev, xCurrent, yCurrent, xNext, yNext);
                                    result = await partOfTheDirection;
                                    //locationName=vertexsOfGraph[index-1].name;
                                    currentDirection=result+locationName;
                                    directions.Add(currentDirection);
                                }
                                
                            }
                            else
                            {
                                xNext =vertexsOfGraph[index].coordinate.x;
                                yNext=vertexsOfGraph[index].coordinate.y;
                                if (z!=vertexsOfGraph[index].coordinate.z)
                                {
                                    if(numOfVertexsInT>1)
                                    {
                                        xNext =vertexsOfGraph[index-1].coordinate.x;
                                        yNext=vertexsOfGraph[index-1].coordinate.y;
                                        partOfTheDirection=GetDirection(xPrev, yPrev, xCurrent, yCurrent, xNext, yNext);
                                        result = await partOfTheDirection;
                                        //locationName=vertexsOfGraph[index-1].name;
                                        currentDirection=result+locationName;
                                        directions.Add(currentDirection);
                                    }
                                    directions.Add("המשך לקומה "+vertexsOfGraph[index].coordinate.z);
                                    
                                }
                                else
                                {
                                    if (vertexsOfGraph[index].name==null)
                                    {
                                        if (numOfVertexsInT>1)
                                        {
                                            directions.Add("המשך עד "+locationName);

                                        }
                                        directions.Add("המשך מעט ");
                                        vertexsOfFloor.Add(vertexsOfFloor[index]);
                                        index++;
                                        while (index<listLength&&vertexsOfGraph[index].name==null)
                                        {
                                            vertexsOfFloor.Add(vertexsOfGraph[index]);
                                            index++;
                                            directions.Add("המשך עוד");
                                        }
                                    }
                                    else
                                    {
                                        partOfTheDirection=GetDirection(xPrev, yPrev, xCurrent, yCurrent, xNext, yNext);
                                        result = await partOfTheDirection;
                                        locationName=vertexsOfGraph[index].name;
                                        currentDirection=result+locationName;
                                        directions.Add(currentDirection);

                                    }
                                    //xNext =vertexsOfGraph[index].coordinate.x;
                                    //yNext=vertexsOfGraph[index].coordinate.y;

                                   

                                    xPrev=xCurrent;
                                    yPrev=yCurrent;
                                    xCurrent=xNext;
                                    yCurrent=yNext;
                                }
                            }
                        }
                    }
                }
               
                TheCenterPhoto=await _TheCenterPhotoService.GetByZAsync(z, centerId);
                floor=new Floor(vertexsOfFloor, directions, TheCenterPhoto);
                floors.Add(floor);
                directions=new List<string>();
                vertexsOfFloor=new List<VertexOfGraph>();
                TheCenterPhoto=new List<TheCenterPhotoDTO>();

            }
            return floors;

        }

    }

}





















