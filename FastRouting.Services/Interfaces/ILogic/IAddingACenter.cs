using FastRouting.Common.DTO;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRouting.Services.Interfaces.ILogic
{
    public interface IAddingACenter
    {
        Task<object> BuildingEdges(List<LocationsDTO> Locations, List<IntersectionsDTO> Intersections, List<List<int>> PassCodes) ;
         double CalcDistance(double x1, double y1, double x2, double y2) ;
         Task<bool> CreateNewCenter(CentersDTO shoppingMall, List<TheCenterPhotoDTO> TheCenterPhotoDTOList, List<LocationsDTO> locations, List<IntersectionsDTO> intersections, List<List<int>> passCodes, JToken edgesCrossing, JToken edgesCrossTrasitions);
         Task DataPreparationFunc(string centerName, string jsonString, List<Image> images);
    }
}
