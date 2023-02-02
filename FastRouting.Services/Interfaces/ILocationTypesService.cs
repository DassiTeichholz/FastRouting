using FastRouting.Common.DTO;
using FastRouting.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRouting.Services.Interfaces
{
    public interface ILocationTypesService
    {
        Task<List<LocationTypesDTO>> GetAllAsync();
        Task<LocationTypesDTO> GetByIdAsync(int locationTypeId);
        Task<LocationTypesDTO> AddAsync(LocationTypesDTO LocationTypes);
        Task<LocationTypesDTO> UpdateAsync(LocationTypesDTO LocationTypes);
        Task DeleteAsync(int locationTypeId);//מחיקה לפי מזהה סוג מיקום
    }
}
