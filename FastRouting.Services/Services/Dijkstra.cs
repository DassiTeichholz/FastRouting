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
    
       
    public class Dijkstra
    {
        public List<LocationsDTO> locations;
        public List<IntersectionsDTO> intersections;
        public List<EdgesDTO> edges;
        public int sourceId;
        public int destinationId;

        public Dijkstra(List<LocationsDTO> locations, List<IntersectionsDTO> intersections, List<EdgesDTO> edges, int sourceId, int destinationId)
        {
            this.locations = locations;
            this.intersections = intersections;
            this.edges = edges;
            this.sourceId = sourceId;
            this.destinationId = destinationId;
        }

        public List<LocationsDTO> GetShortestPath()
        {
            Dictionary<int, double> distance = new Dictionary<int, double>();
            Dictionary<int, int> previous = new Dictionary<int, int>();
            List<int> unvisited = new List<int>();

            // Initialize all distances to infinity and set all nodes as unvisited
            foreach (var location in locations)
            {
                distance[location.Id] = double.MaxValue;
                previous[location.Id] = -1;
                unvisited.Add(location.Id);
            }

            // Set the distance of the source node to 0
            distance[sourceId] = 0;

            while (unvisited.Count != 0)
            {
                // Get the node with the smallest distance from the unvisited set
                int current = GetNextNode(distance, unvisited);

                // If we have reached the destination, stop
                if (current == destinationId)
                    break;

                // Remove the current node from the unvisited set
                unvisited.Remove(current);

                // Update the distances of the neighbors
                foreach (var edge in edges)
                {
                    int neighbor = -1;
                    if (edge.LocationIdA == current)
                        neighbor = edge.LocationIdB;
                    else if (edge.LocationIdB == current)
                        neighbor = edge.LocationIdA;

                    if (neighbor != -1 && unvisited.Contains(neighbor))
                    {
                        double newDistance = distance[current] + edge.Distance;
                        if (newDistance < distance[neighbor])
                        {
                            distance[neighbor] = newDistance;
                            previous[neighbor] = current;
                        }
                    }
                }
            }

            // Build the path from the source to the destination
            List<LocationsDTO> path = new List<LocationsDTO>();
            int node = destinationId;
            while (node != -1)
            {
                LocationsDTO location = locations.Find(x => x.Id == node);
                path.Insert(0, location);
                node = previous[node];
            }

            return path;
        }

        private int GetNextNode(Dictionary<int, double> distance, List<int> unvisited)
        {
            int nextNode = -1;
            double minDistance = double.MaxValue;

            foreach (var node in unvisited)
            {
                if (distance[node] < minDistance)
                {
                    minDistance = distance[node];
                    nextNode = node;
                }
            }

            return nextNode;
        }


    }
}
