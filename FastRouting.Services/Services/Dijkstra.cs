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
using FastRouting.Services.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Xml.Linq;
using System;
using System.Collections.Generic;



namespace FastRouting.Services.Services
{
   
    
    //קלאס זה מכיל את הקשתות המקוריות + תרגום מזהי המיקומים לאינדקס שלהם בגרף
    public class EdgeOfGraph 
    {
        public int IndexA { get; set; }
        public int IndexB { get; set; }

        public EdgesDTO Edge { get; set; }
        public EdgeOfGraph( EdgesDTO edge)
        {
            Edge = edge;
        }
    }

   
    public class VertexOfGraph
    {
        //public int num { get; set; }
        //private int vertexNum;
        public CoordinateDTO coordinate { get; set; }
        public LocationTypesDTO LocationTypes { get; set; }
        public string name { get; set; }
        public List<EdgeOfGraph> EdgesOfGraphs { get; set; }
        //private int num;

        public VertexOfGraph(CoordinateDTO coordinate, LocationTypesDTO LocationTypes, string name/*, int num*/)
        {
            this.coordinate = coordinate;
            this.LocationTypes = LocationTypes;
            this.name = name;
            this.EdgesOfGraphs = new List<EdgeOfGraph>();
           // this.num = num;
        }
        public VertexOfGraph(CoordinateDTO coordinate/*, int num*/)
        {
           // this.num = num;
            this.coordinate = coordinate;
            this.LocationTypes = null; 
            this.name = null;
            this.EdgesOfGraphs = new List<EdgeOfGraph>();

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




    public static class Dijkstra
    {



        
        public static VertexOfGraph[] PreparingTheGraph(List<LocationsDTO> locations, List<IntersectionsDTO> intersections, List<EdgesDTO> edges)
        {
            int index = 0;
            VertexOfGraph[] graph = new VertexOfGraph[locations.Count + intersections.Count];
            List<EdgeOfGraph> listEdgeOfGraph = new List<EdgeOfGraph>();
            foreach(var edge in edges)
            {
                EdgeOfGraph edgeOfGraph = new EdgeOfGraph(edge);
                listEdgeOfGraph.Add(edgeOfGraph);
            }


            foreach (var location in locations)
            {
                //List<EdgeOfGraph> listEdgeOfGraph = new List<EdgeOfGraph>();

                foreach (var edgeOfGraph in listEdgeOfGraph)
                {
                    if(location.coordinate.id==edgeOfGraph.Edge.LocationIdA)
                    {
                        edgeOfGraph.IndexA = index;
                    }
                    else
                    {
                        if(location.coordinate.id==edgeOfGraph.Edge.LocationIdB){

                            edgeOfGraph.IndexB = index;
                        }
                    }

                    
                }

                VertexOfGraph VertexOfGraph = new VertexOfGraph(location.coordinate, location.locationTypes, location.locationName/*, index*/);

                graph[index] = VertexOfGraph;
                index++;

            }

            foreach (var intersection in intersections)
            {
                //List<EdgeOfGraph> listEdgeOfGraph = new List<EdgeOfGraph>();

                foreach (var edgeOfGraph in listEdgeOfGraph)
                {
                    if (intersection.Coordinate.id==edgeOfGraph.Edge.LocationIdA)
                    {
                        edgeOfGraph.IndexA = index;
                    }
                    else
                    {
                        if (intersection.Coordinate.id==edgeOfGraph.Edge.LocationIdB)
                        {

                            edgeOfGraph.IndexB = index;
                        }
                    }


                }

                VertexOfGraph VertexOfGraph = new VertexOfGraph(intersection.Coordinate);

                graph[index] = VertexOfGraph;
                index++;

            }
            foreach(var egdeOfGraph in listEdgeOfGraph)
            {
                graph[egdeOfGraph.IndexA].EdgesOfGraphs.Add(egdeOfGraph);
            }



            return graph;
        }

        //חשוב מאד!!
        //המקור והיעד הם האינדקסים של המקומות בגרף המבטאים מקור ויעד
        public static List<VertexOfGraph> DijkstraAlgorithm(int src, int dest ,VertexOfGraph[] graph)
        {
            List<VertexOfGraph> VertexOfGraph=new List<VertexOfGraph>();
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
                if(current.getVertex()== dest)
                {
                    break;
                }
                pq.Remove(current);

                foreach (EdgeOfGraph n in graph[current.getVertex()].EdgesOfGraphs)
                {

                    if (distance[current.getVertex()]  + n.Edge.Distance< distance[n.IndexB])
                    {
                        distance[n.IndexB]=distance[current.getVertex()] + +n.Edge.Distance;
                        parent[n.IndexB] = current.getVertex();

                        pq.Add(new AdjListNode(
                          n.IndexB,
                          distance[n.IndexB]));
                    }
                }
            }
            int currentVertexOfGraph=dest;
            while (currentVertexOfGraph!=src)
            {
                graph[currentVertexOfGraph].EdgesOfGraphs=null;
                VertexOfGraph.Insert(0, graph[currentVertexOfGraph]);
                currentVertexOfGraph=parent[currentVertexOfGraph];
            }
            graph[src].EdgesOfGraphs=null;
            VertexOfGraph.Insert(0, graph[src]);




            return VertexOfGraph;
        }

    }

}



















   

