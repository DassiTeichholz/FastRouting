using FastRouting.Common.DTO;
using FastRouting.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRouting.Services.Interfaces
{
    public interface ICentersService
    {
        Task<List<CentersDTO>> GetAllAsync();
        Task<CentersDTO> GetByIdAsync(int id);
        Task<CentersDTO> GetByNameAsync(string name);
        Task<CentersDTO> AddAsync(CentersDTO Centers);
       // Task<bool> CreateNewMall(CentersDTO shoppingMall, List<TheCenterPhotoDTO> TheCenterPhotoDTOList, List<LocationsDTO> locations, List<IntersectionsDTO> intersections, List<List<int>> passCodes, List<object> edgesCrossFloors);
        Task<CentersDTO> UpdateAsync(CentersDTO Centers);
        Task DeleteAsync(int id);
       // Task DataPreparationFunc(string centerName);
    }
}
