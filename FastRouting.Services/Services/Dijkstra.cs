using FastRouting.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;


namespace FastRouting.Services.Services
{



    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Dijkstra
    {
        private List<LocationsDTO> locations;
        private List<IntersectionsDTO> intersections;
        private List<EdgesDTO> edges;

        public Dijkstra(List<LocationsDTO> locations, List<IntersectionsDTO> intersections, List<EdgesDTO> edges)
        {
            this.locations = locations;
            this.intersections = intersections;
            this.edges = edges;
        }

        public List<LocationsDTO> ShortestPath(int source, int destination)
        {
            Dictionary<int, double> distance = new Dictionary<int, double>();
            Dictionary<int, int> previous = new Dictionary<int, int>();
            List<int> unvisited = new List<int>();

            foreach (var location in locations)
            {
                distance[location.Id] = double.MaxValue;
                previous[location.Id] = -1;
                unvisited.Add(location.Id);
            }
            distance[source] = 0;

            while (unvisited.Count != 0)
            {
                int minId = unvisited.OrderBy(x => distance[x]).First();
                unvisited.Remove(minId);

                foreach (var edge in edges.Where(x => x.LocationIdA == minId || x.LocationIdB == minId))
                {
                    int neighborId = edge.LocationIdA == minId ? edge.LocationIdB : edge.LocationIdA;
                    if (unvisited.Contains(neighborId))
                    {
                        double newDistance = distance[minId] + edge.Distance;
                        if (newDistance < distance[neighborId])
                        {
                            distance[neighborId] = newDistance;
                            previous[neighborId] = minId;
                        }
                    }
                }
            }

            List<LocationsDTO> result = new List<LocationsDTO>();
            int current = destination;
            while (current != -1)
            {
                result.Add(locations.First(x => x.Id == current));
                current = previous[current];
            }
            result.Reverse();
            return result;
        }
    }





















    //using System;
    //using System.Collections.Generic;

    //public class Dijkstra
    //{



    //    //    public List<object> DijkstraShortestPath(List<LocationsDTO> locations, List<IntersectionsDTO> intersections, int sourceId, int destinationId)
    //    //    {
    //    //        int n = locations.Count + intersections.Count;
    //    //        double[] distances = new double[n];
    //    //        int[] previous = new int[n];
    //    //        bool[] visited = new bool[n];

    //    //        for (int i = 0; i < n; i++)
    //    //        {
    //    //            distances[i] = double.MaxValue;
    //    //            previous[i] = -1;
    //    //        }

    //    //        distances[sourceId] = 0;

    //    //        for (int i = 0; i < n; i++)
    //    //        {
    //    //            int current = GetNextNode(distances, visited);
    //    //            visited[current] = true;

    //    //            if (current == destinationId)
    //    //            {
    //    //                break;
    //    //            }

    //    //            foreach (var edge in locations[current].Transitions.Edges)
    //    //            {
    //    //                int neighbor = edge.LocationIdB;
    //    //                double weight = edge.Distance;

    //    //                if (visited[neighbor])
    //    //                {
    //    //                    continue;
    //    //                }

    //    //                if (distances[current] + weight < distances[neighbor])
    //    //                {
    //    //                    distances[neighbor] = distances[current] + weight;
    //    //                    previous[neighbor] = current;
    //    //                }
    //    //            }
    //    //        }

    //    //        List<object> path = new List<object>();
    //    //        int currentNode = destinationId;

    //    //        while (currentNode != -1)
    //    //        {
    //    //            if (currentNode < locations.Count)
    //    //            {
    //    //                path.Add(locations[currentNode]);
    //    //            }
    //    //            else
    //    //            {
    //    //                path.Add(intersections[currentNode - locations.Count]);
    //    //            }
    //    //            currentNode = previous[currentNode];
    //    //        }

    //    //        path.Reverse();

    //    //        return path;
    //    //    }

    //    //    private int GetNextNode(double[] distances, bool[] visited)
    //    //    {
    //    //        int nextNode = -1;
    //    //        double minDistance = double.MaxValue;

    //    //        for (int i = 0; i < distances.Length; i++)
    //    //        {
    //    //            if (visited[i])
    //    //            {
    //    //                continue;
    //    //            }

    //    //            if (distances[i] < minDistance)
    //    //            {
    //    //                minDistance = distances[i];
    //    //                nextNode = i;
    //    //            }
    //    //        }

    //    //        return nextNode;
    //    //    }






    //    //}





    //    public List<object> DijkstraShortestPath(List<LocationsDTO> locations, List<IntersectionsDTO> intersections, int sourceId, int destinationId)
    //    {
    //        int n = locations.Count + intersections.Count;
    //        Dictionary<int, double> distances = new Dictionary<int, double>();
    //        Dictionary<int, int> previous = new Dictionary<int, int>();
    //        HashSet<int> visited = new HashSet<int>();

    //        for (int i = 0; i < n; i++)
    //        {
    //            int id;
    //            if (i < locations.Count)
    //            {
    //                id = locations[i].Coordinate.Id;
    //            }
    //            else
    //            {
    //                id = intersections[i - locations.Count].Coordinate.Id;
    //            }
    //            distances[id] = double.MaxValue;
    //            previous[id] = -1;
    //        }

    //        distances[sourceId] = 0;

    //        for (int i = 0; i < n; i++)
    //        {
    //            int current = GetNextNode(distances, visited);
    //            visited.Add(current);

    //            if (current == destinationId)
    //            {
    //                break;
    //            }

    //            LocationsDTO currentLocation = locations.Find(loc => loc.Id == current);
    //            foreach (var edge in currentLocation.Transitions.Edges)
    //            {
    //                int neighbor = edge.LocationIdB;
    //                double weight = edge.Distance;

    //                if (visited.Contains(neighbor))
    //                {
    //                    continue;
    //                }

    //                if (distances[current] + weight < distances[neighbor])
    //                {
    //                    distances[neighbor] = distances[current] + weight;
    //                    previous[neighbor] = current;
    //                }
    //            }
    //        }

    //        List<object> path = new List<object>();
    //        int currentNode = destinationId;

    //        while (currentNode != -1)
    //        {
    //            LocationsDTO location = locations.Find(loc => loc.Id == currentNode);
    //            if (location != null)
    //            {
    //                path.Add(location);
    //            }
    //            else
    //            {
    //                IntersectionsDTO intersection = intersections.Find(inter => inter.Id == currentNode);
    //                path.Add(intersection);
    //            }
    //            currentNode = previous[currentNode];
    //        }

    //        path.Reverse();

    //        return path;
    //    }

    //    private int GetNextNode(Dictionary<int, double> distances, HashSet<int> visited)
    //    {
    //        int nextNode = -1;
    //        double minDistance = double.MaxValue;

    //        foreach (var item in distances)
    //        {
    //            int node = item.Key;
    //            if (visited.Contains(node))
    //            {
    //                continue;
    //            }

    //            if (item.Value < minDistance)
    //            {
    //                minDistance = item.Value;
    //                nextNode = node;
    //            }
    //        }

    //        return nextNode;
    //    }

    //}
}
