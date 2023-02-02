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
        Task<List<Locations>> GetAllAsync();
        Task<Locations> GetByIDAsync(int ID);
        Task<Locations> AddAsync(Locations Locations);
        Task<Locations> UpdateAsync(Locations Locations);
        Task DeleteAsync(int Id);//מחיקה לפי מזהה הצטלבות
    }
}
