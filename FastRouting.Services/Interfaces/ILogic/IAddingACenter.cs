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
         Task<bool> CreateNewMall(ShoppingMallsDTO shoppingMall/*, List<TheMallPhotosDTO> theMallPhotosDTOList*/, List<LocationsDTO> locations, List<IntersectionsDTO> intersections, List<List<int>> passCodes/*, List<dynamic> edgesCrossFloors*/, JToken edgesCrossing);
         Task DataPreparationFunc(string centerName);




    }
}
