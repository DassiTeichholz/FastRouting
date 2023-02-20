using FastRouting.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using FastRouting.Common.DTO;
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
    //public class internalObject
    //{
    //    public int idCoordinate;
    //    public double distance;

    //    public internalObject(int idCoordinate, double distance)
    //    {
    //        this.idCoordinate = idCoordinate;
    //        this.distance = distance;
    //    }
    //}
    public class EdgeOfGraph
    {
        public int num { get; set; }
        public EdgesDTO Edge { get; set; }
        public EdgeOfGraph(int num, EdgesDTO edge)
        {
            this.num = num;
            Edge = edge;
        }
    }

    public class HeapItem
    {
        public int id;
        public double distance;
        public HeapItem(int id, double distance)
        {
            this.id = id;
            this.distance = distance;
        }

    }






    public class VertexOfGraph
    {
        public int num { get; set; }
        //private int vertexNum;
        public CoordinateDTO coordinate { get; set; }
        public LocationTypesDTO LocationTypes { get; set; }
        public string name { get; set; }
        public List<EdgeOfGraph> EdgesOfGraphs { get; set; }
        //private int num;

        public VertexOfGraph(CoordinateDTO coordinate, LocationTypesDTO LocationTypes, string name, int num, List<EdgeOfGraph> listEdgeOfGraph)
        {
            this.coordinate = coordinate;
            this.LocationTypes = LocationTypes;
            this.name = name;
            this.EdgesOfGraphs = listEdgeOfGraph;
            this.num = num;
        }
        public VertexOfGraph(CoordinateDTO coordinate, int num, List<EdgeOfGraph> listEdgeOfGraph)
        {
            this.num = num;
            this.coordinate = coordinate;
            this.LocationTypes = null; ;
            this.name = null;
            this.EdgesOfGraphs = listEdgeOfGraph;

        }
    }




    public static class Dijkstra
    {



        //הקשתות איתן נעבוד לחישוב האלגוריתם, מכילות מספר



        public static List<VertexOfGraph> Dijkstra(int src, int dest, List<LocationsDTO> locations, List<IntersectionsDTO> intersections, List<EdgesDTO> edges)
        {


            VertexOfGraph[] graph = new VertexOfGraph[locations.Count + intersections.Count];
            // double[] heapArray = new double[locations.Count + intersections.Count];

            int index = 0;
            foreach (var location in locations)
            {
                List<EdgeOfGraph> listEdgeOfGraph = new List<EdgeOfGraph>();
                foreach (var edge in edges)
                {
                    if (edge.LocationIdA == location.Coordinate.Id)
                    {
                        EdgeOfGraph EdgesOfGraph = new EdgeOfGraph(index, edge);


                        listEdgeOfGraph.Add(EdgesOfGraph);
                    }
                }

                VertexOfGraph VertexOfGraph = new VertexOfGraph(location.Coordinate, location.LocationTypes, location.LocationName, index, listEdgeOfGraph);

                graph[index] = VertexOfGraph;
                index++;

            }

            foreach (var intersection in intersections)
            {
                List<EdgeOfGraph> listEdgeOfGraph = new List<EdgeOfGraph>();
                foreach (var edge in edges)
                {
                    if (edge.LocationIdA == intersection.Coordinate.Id)
                    {
                        EdgeOfGraph EdgesOfGraph = new EdgeOfGraph(index, edge);


                        listEdgeOfGraph.Add(EdgesOfGraph);
                    }
                }

                VertexOfGraph VertexOfGraph = new VertexOfGraph(intersection.Coordinate, index, listEdgeOfGraph);

                graph[index] = VertexOfGraph;
                index++;

            }


            int[] prev = new int[graph.Length];
            bool[] isVisit = new bool[graph.Length];
            double[] dist = new double[graph.Length];

            for (int i = 0; i < graph.Length; i++)
            {
                dist[i] = int.MaxValue;
                prev[i] = -1;
            }

            dist[src] = 0;
            var pq = new PriorityQueue<HeapItem, double>();
            HeapItem HeapItem = new HeapItem(src, 0);
            pq.Enqueue(HeapItem, 0);
            while (pq.Count > 0)
            {
                HeapItem curr;
                curr = pq.Dequeue();
                int u = ;
                if (u == dest)
                {
                    break; // if the destination vertex is reached, exit early
                }
                if (curr[0] > dist[u])
                {
                    continue; // if a shorter distance to u is already known, skip it
                }
                foreach (int v in adj[u])
                {
                    int alt = dist[u] + 1; // in this case, the weight of the edges is 1
                    if (alt < dist[v])
                    {
                        dist[v] = alt;
                        prev[v] = u;
                        pq.Enqueue(new int[] { alt, v });
                    }
                }
            }
        }

    }

}



















   

