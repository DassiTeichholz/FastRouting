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

namespace FastRouting.Services.Services.Logic
{
   

//קלאס זה מכיל את הקשתות המקוריות + תרגום מזהי המיקומים לאינדקס שלהם בגרף
    public class EdgeOfGraph
    {
        public int IndexA { get; set; }
        public int IndexB { get; set; }

        public EdgesDTO Edge { get; set; }
        public EdgeOfGraph(EdgesDTO edge)
        {
            Edge = edge;
        }
    }

    public class Floor
    {
        public List<VertexOfGraph> vertexsOfFloor  { get; set; }
        public List<string> directions { get; set; }
        public List<TheMallPhotosDTO> theMallPhotosDTO  { get; set; }

        public Floor()
        {
            this.vertexsOfFloor = new List<VertexOfGraph>();
            this.directions = new List<string>();
            this.theMallPhotosDTO= new List<TheMallPhotosDTO>();
        }
        public Floor(List<VertexOfGraph> vertexsOfFloor, List<string> directions, List<TheMallPhotosDTO> theMallPhotosDTO)
        {
            this.theMallPhotosDTO = theMallPhotosDTO;
            this.directions=directions;
            this.vertexsOfFloor=vertexsOfFloor;
            
        }
    }



    public class VertexOfGraph
    {
        //public int num { get; set; }
        //private int vertexNum;
        public CoordinateDTO coordinate { get; set; }
        public LocationTypesDTO LocationTypes { get; set; }
        public string name { get; set; }
        public int trasition { get; set; }
        public List<EdgeOfGraph> EdgesOfGraphs { get; set; }
        //private int num;

        public VertexOfGraph(CoordinateDTO coordinate, LocationTypesDTO LocationTypes, string name/*, int num*/, int trasition)
        {
            this.coordinate = coordinate;
            this.LocationTypes = LocationTypes;
            this.name = name;
            EdgesOfGraphs = new List<EdgeOfGraph>();
            this.trasition = trasition;
            // this.num = num;
        }
        public VertexOfGraph(CoordinateDTO coordinate/*, int num*/)
        {
            // this.num = num;
            this.coordinate = coordinate;
            LocationTypes = null;
            name = null;
            
            EdgesOfGraphs = new List<EdgeOfGraph>();

        }
    }
    public class AdjListNode : IComparable<AdjListNode>
    {
        private int vertex;
        private double weight;
        public AdjListNode(int v, double w)
        {
            vertex = v;
            weight = w;
        }
        public int getVertex() { return vertex; }
        public double getWeight() { return weight; }
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
            return 0;
        }
    }


   

public  class RouteCalculation: IRouteCalculation
    {
        private readonly IshoppingMallsService _shoppingMallService;
        private readonly ILocationsService _locationsService;
        private readonly IIntersectionsService _IntersectionsService;
        private readonly ITheMallPhotosService _theMallPhotosService;
        private readonly IMapper _mapper;
        private readonly IEdgesService _edgesService;
        private readonly ITransitionsService _transitionsService;
        private readonly ILocationTypesService _locationTypesService;
        private readonly ITransitionsToIntersectionsService _transitionsToIntersectionsService;
        public RouteCalculation(IMapper mapper, IshoppingMallsService shoppingMallService, IEdgesService edgesService, ITheMallPhotosService theMallPhotosService, IIntersectionsService intersectionsService, ILocationsService locationsService, ITransitionsService transitionsService, ILocationTypesService locationTypesService, ITransitionsToIntersectionsService transitionsToIntersectionsService)
        {
            _mapper = mapper;
            _shoppingMallService = shoppingMallService;
            _edgesService = edgesService;
            _theMallPhotosService = theMallPhotosService;
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
                    if (location.coordinate.id == edgeOfGraph.Edge.LocationIdA)
                    {
                        edgeOfGraph.IndexA = index;
                    }
                    else
                    {
                        if (location.coordinate.id == edgeOfGraph.Edge.LocationIdB)
                        {

                            edgeOfGraph.IndexB = index;
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
                    if (intersection.Coordinate.id == edgeOfGraph.Edge.LocationIdA)
                    {
                        edgeOfGraph.IndexA = index;
                    }
                    else
                    {
                        if (intersection.Coordinate.id == edgeOfGraph.Edge.LocationIdB)
                        {

                            edgeOfGraph.IndexB = index;
                        }
                    }


                }

                VertexOfGraph VertexOfGraph = new VertexOfGraph(intersection.Coordinate);

                graph[index] = VertexOfGraph;
                index++;

            }
            foreach (var egdeOfGraph in listEdgeOfGraph)
            {
                graph[egdeOfGraph.IndexA].EdgesOfGraphs.Add(egdeOfGraph);
            }


            List<Floor> vertexOfGraphs;
            vertexOfGraphs=await DijkstraAlgorithm(src,dest,graph);
            return vertexOfGraphs;
        }

        //חשוב מאד!!
        //המקור והיעד הם האינדקסים של המקומות בגרף המבטאים מקור ויעד
        public async Task<List<Floor>> DijkstraAlgorithm(int src, int dest, VertexOfGraph[] graph)
        {
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

                foreach (EdgeOfGraph n in graph[current.getVertex()].EdgesOfGraphs)
                {

                    if ((distance[current.getVertex()] + n.Edge.Distance < distance[n.IndexB])/*||(((distance[current.getVertex()] + n.Edge.Distance) == distance[n.IndexB])&&(graph[current.getVertex()].name!=null))*/)
                    {
                        distance[n.IndexB] = distance[current.getVertex()] + n.Edge.Distance;
                        parent[n.IndexB] = current.getVertex();

                        pq.Add(new AdjListNode(
                          n.IndexB,
                          distance[n.IndexB]));
                    }
                }
            }
            int currentVertexOfGraph = dest;
            while (currentVertexOfGraph != src)
            {
                graph[currentVertexOfGraph].EdgesOfGraphs = null;
                VertexOfGraph.Insert(0, graph[currentVertexOfGraph]);
                currentVertexOfGraph = parent[currentVertexOfGraph];
            }
            graph[src].EdgesOfGraphs = null;
            VertexOfGraph.Insert(0, graph[src]);




            return await  GetRoute(VertexOfGraph);
        }

        
        public async Task<string> GetDirection(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            double angle1 = Math.Atan2(y2 - y1, x2 - x1) * 180 / Math.PI;
            double angle2 = Math.Atan2(y3 - y2, x3 - x2) * 180 / Math.PI;
            double angle = angle2 - angle1;
            if (angle < -180) angle += 360;
            if (angle > 180) angle -= 360;

            if (angle < -30) return "turn left to ";
            if (angle > 30) return "turn right to ";
            return "continue straight to ";
        } 

        public async Task<List<Floor>> GetRoute(List<VertexOfGraph> vertexsOfGraph)
        {
            Floor floor;
            List<Floor> floors = new List<Floor>();
            List<string> directions=new List<string>();
            List<VertexOfGraph> vertexsOfFloor=new List<VertexOfGraph>();
            List<TheMallPhotosDTO> theMallPhotos=new List<TheMallPhotosDTO>();
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
            int listLength = vertexsOfGraph.Count;
            int z= vertexsOfGraph[index].coordinate.z;
            //כל סיבוב לולאה בלולאה החיצונית, מבטא אובייקט "קומה" חדש
            while (index<listLength)
            {
                z= vertexsOfGraph[index].coordinate.z;
                xPrev= vertexsOfGraph[index].coordinate.x;
                yPrev= vertexsOfGraph[index].coordinate.y;
                vertexsOfFloor.Add(vertexsOfGraph[index]);
                trasition = vertexsOfGraph[index].trasition;
                index++;
                //טיפול נפרד במעבר הראשון בקומה, בו כיוון ההדרכה נמדד אחרת
                if (vertexsOfGraph[index].name != null)
                { 
                 while (index<listLength&&z==vertexsOfGraph[index].coordinate.z&&(trasition==vertexsOfGraph[index].trasition||vertexsOfGraph[index].trasition==0))
                 {
                    vertexsOfFloor.Add(vertexsOfGraph[index]);
                    index++;
                    if (index<listLength&&(z!=vertexsOfGraph[index].coordinate.z||vertexsOfGraph[index].trasition==0))
                    {
                        locationName=vertexsOfGraph[index-1].name;
                    }
                 }
                    currentDirection=locationName+" התקדם לכוון";
                    directions.Add(currentDirection);
                }
                else
                {
                    vertexsOfFloor.Add(vertexsOfGraph[index]);
                    index++;
                }
                //if (vertexsOfFloor.Count>1)
                //{
                //    currentDirection=locationName+" התקדם לכוון";
                //    directions.Add(currentDirection);
                //}
                
                xCurrent =vertexsOfGraph[index-1].coordinate.x;
                yCurrent=vertexsOfGraph[index-1].coordinate.y;
                //trasition=vertexsOfGraph[index].trasition;
                //כל סיבוב בלולאה זו, זה מעבר נוסף בקומה הנוכחית
                while (index<listLength&&z==vertexsOfGraph[index].coordinate.z)
                {
                    trasition=vertexsOfGraph[index].trasition;

                    while (index<listLength&&(trasition==vertexsOfGraph[index].trasition||vertexsOfGraph[index].trasition==0))
                    {
                        vertexsOfFloor.Add(vertexsOfGraph[index]);
                        index++;
                        if (index>=listLength||(index<listLength&&(z!=vertexsOfGraph[index].coordinate.z||vertexsOfGraph[index].trasition==0)))
                        {
                            locationName=vertexsOfGraph[index-1].name;
                        }
                    }
                    xNext=vertexsOfGraph[index-1].coordinate.x;
                    yNext=vertexsOfGraph[index-1].coordinate.y;
                    partOfTheDirection=GetDirection(xPrev, yPrev, xCurrent, yCurrent, xNext, yNext);
                    result = await partOfTheDirection;
                    currentDirection=result+locationName;
                    directions.Add(currentDirection);
                    xPrev=xCurrent;
                    yPrev=yCurrent;
                    xCurrent=xNext;
                    yCurrent=yNext;
                }
                theMallPhotos=await _theMallPhotosService.GetByZAsync(z);
                floor=new Floor(vertexsOfFloor, directions,theMallPhotos);
                floors.Add(floor);
                directions=new List<string>();
                vertexsOfFloor=new List<VertexOfGraph>();
                theMallPhotos=new List<TheMallPhotosDTO>();
            }
            return floors;

        }

    }

}





















