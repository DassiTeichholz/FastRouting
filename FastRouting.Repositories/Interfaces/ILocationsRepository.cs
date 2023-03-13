using FastRouting.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRouting.Repositories.Interfaces
{
    public interface ILocationsRepository
    {
        Task<List<Location>> GetAllAsync();
        Task<Location> GetByIDAsync(int id);
        Task<List<Location>> GetByCenterIdAsync(int id);
        Task<Location> GetByNameAsync(string name);
        Task<Location> AddAsync(Location Locations);
        Task<Location> UpdateAsync(Location Locations);
        Task DeleteAsync(int Id);//מחיקה לפי מזהה הצטלבות
    }
}
