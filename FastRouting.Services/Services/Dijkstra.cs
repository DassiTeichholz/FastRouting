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


namespace FastRouting.Services.Services
{



    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Metrics;
    using System.Linq;
    using System.Xml.Linq;

    public static class Dijkstra
    {
        public class internalObject
        {
            public int idCoordinate;
            public double distance;

            public internalObject(int idCoordinate, double distance)
            {
                this.idCoordinate=idCoordinate;
                this.distance=distance;
            }
        }

        public class Vertex
        {
            //private int vertexNum;
            private CoordinateDTO coordinate;
            private LocationTypesDTO LocationTypes;
            private string name;
            private List<internalObject> internalObject;
            //private int num;

            public Vertex(CoordinateDTO coordinate, LocationTypesDTO LocationTypes,string name)
            {
                this.coordinate = coordinate;
                this.LocationTypes = LocationTypes;
                this.name = name;
                this.internalObject = new List<internalObject>();
            }
            public Vertex(CoordinateDTO coordinate)
            {
                this.coordinate = coordinate;
                this.LocationTypes = null; ;
                this.name = null;

            }
        }
        public static List<Vertex> Dijkstra(int startId, int endId, List<LocationsDTO> locations, List<IntersectionsDTO> intersections, List<EdgesDTO> edges)
        {

            int[] parent = new int[locations.Count+intersections.Count];
            bool[] isVisit = new bool[locations.Count+intersections.Count];
            double[] distance = new double[locations.Count+intersections.Count];
            Vertex[] graph = new Vertex[locations.Count+intersections.Count];
            double[] heapArray = new double[locations.Count+intersections.Count];

            foreach (Vertex edge in graph) 
            {
                int index = IntStream.range(0, persons.length)
                                     .filter(i->persons[i].id == 5)
                                     .findFirst()
                                     .orElse(-1);
            }







        }



    }
}
