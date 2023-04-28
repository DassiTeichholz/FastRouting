using FastRouting.Common.DTO;
using FastRouting.Services.Services.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRouting.Services.Interfaces.ILogic
{
    public interface IRouteCalculation
    {
        Task<List<Floor>> MainFunction(string nameSource, string nameDestination,int idCenter);
        Task<List<Floor>> PreparingTheGraph(List<LocationsDTO> locations, List<IntersectionsDTO> intersections, List<EdgesDTO> edges, string nameSource, string nameDestination)
;
        Task<List<Floor>> DijkstraAlgorithm(int src, int dest, VertexOfGraph[] graph,int centerId);
        Task<List<Floor>> GetRoute(List<VertexOfGraph> vertexsOfGraph, int centerId);

    }
}
