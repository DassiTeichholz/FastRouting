using FastRouting.Common.DTO;
using FastRouting.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRouting.Services.Interfaces
{
    public interface IshoppingMallsService
    {
        Task<List<ShoppingMallsDTO>> GetAllAsync();
        Task<ShoppingMallsDTO> GetByIdAsync(int id);
        Task<ShoppingMallsDTO> GetByNameAsync(string name);
        Task<ShoppingMallsDTO> AddAsync(ShoppingMallsDTO shoppingMalls);
        Task<bool> CreateNewMall(string centerName, List<TheMallPhotosDTO> theMallPhotosDTOList, List<LocationsDTO> locations, List<IntersectionsDTO> intersections, List<int>[] passCodes, List<object> edgesCrossFloors);
        Task<ShoppingMallsDTO> UpdateAsync(ShoppingMallsDTO shoppingMalls);
        Task DeleteAsync(int id);
    }
}
