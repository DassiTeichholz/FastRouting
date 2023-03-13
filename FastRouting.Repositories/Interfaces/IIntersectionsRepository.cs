using FastRouting.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRouting.Repositories.Interfaces
{
    public interface IIntersectionsRepository//הצטלבות
    {
        Task<List<Intersections>> GetAllAsync();
        Task<Intersections> GetByIdAsync(int IntersectionID);
        Task<List<Intersections>> GetBycenterIdAsync(int id);
        Task<Intersections> AddAsync(Intersections Intersections);
        Task<Intersections> UpdateAsync(Intersections Intersections);
        Task DeleteAsync(int IntersectionID);//מחיקה לפי מזהה הצטלבות
                                       

    }
}
