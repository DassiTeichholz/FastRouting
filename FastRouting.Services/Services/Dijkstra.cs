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

    //public class HeapItem
    //{
    //    public int id;
    //    public double distance;
    //    public HeapItem(int id, double distance)
    //    {
    //        this.id = id;
    //        this.distance = distance;
    //    }

    //}




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

        public statics int[] ShortestPath(int src)
        {
            int[] dist = new int[V];
            bool[] visited = new bool[V];
            for (int i = 0; i < V; i++)
            {
                dist[i] = int.MaxValue;
            }
            dist[src] = 0;

            var minHeap = new SortedSet<Tuple<int, int>>();
            minHeap.Add(new Tuple<int, int>(0, src));

            while (minHeap.Count > 0)
            {
                var node = minHeap.Min;
                minHeap.Remove(node);

                int u = node.Item2;
                if (visited[u]) continue;
                visited[u] = true;

                foreach (var neighbor in adj[u])
                {
                    int v = neighbor.Item1;
                    int w = neighbor.Item2;
                    if (dist[u] + w < dist[v])
                    {
                        dist[v] = dist[u] + w;
                        if (!visited[v])
                        {
                            minHeap.Add(new Tuple<int, int>(dist[v], v));
                        }
                    }
                }
            }

            return dist;
        }

        //הקשתות איתן נעבוד לחישוב האלגוריתם, מכילות מספר



        public static List<VertexOfGraph> Dijkstra(int startId, int endId, List<LocationsDTO> locations, List<IntersectionsDTO> intersections, List<EdgesDTO> edges)
        {

            int[] parent = new int[locations.Count + intersections.Count];
            bool[] isVisit = new bool[locations.Count + intersections.Count];
            double[] distance = new double[locations.Count + intersections.Count];
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
                
                VertexOfGraph VertexOfGraph = new VertexOfGraph(location.Coordinate,location.LocationTypes,location.LocationName,index, listEdgeOfGraph);

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


        }

    }
}


















   

