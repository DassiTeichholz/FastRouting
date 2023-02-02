using FastRouting.Common.DTO;
using FastRouting.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRouting.Services.Interfaces
{
    public interface ILocationsService
    {
        Task<List<LocationsDTO>> GetAllAsync();
        Task<LocationsDTO> GetByIDAsync(int ID);
        Task<LocationsDTO> AddAsync(LocationsDTO Locations);
        Task<LocationsDTO> UpdateAsync(LocationsDTO Locations);
        Task DeleteAsync(int Id);//מחיקה לפי מזהה הצטלבות
    }
}
