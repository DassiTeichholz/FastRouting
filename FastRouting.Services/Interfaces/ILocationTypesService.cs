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
        Task<List<LocationTypes>> GetAllAsync();
        Task<LocationTypes> GetByIdAsync(int locationTypeId);
        Task<LocationTypes> AddAsync(LocationTypes LocationTypes);
        Task<LocationTypes> UpdateAsync(LocationTypes LocationTypes);
        Task DeleteAsync(int locationTypeId);//מחיקה לפי מזהה סוג מיקום
    }
}
