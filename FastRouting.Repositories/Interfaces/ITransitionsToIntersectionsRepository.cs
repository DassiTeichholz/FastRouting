using FastRouting.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRouting.Repositories.Interfaces
{
    public interface ITransitionsToIntersectionsRepository
    {
        Task<List<TransitionsToIntersections>> GetAllAsync();
        Task<TransitionsToIntersections> GetByIdIdAsync(int IntersectionID, int TransitionId);
        Task<TransitionsToIntersections> AddAsync(TransitionsToIntersections TransitionsToIntersections);
        Task<TransitionsToIntersections> UpdateAsync(TransitionsToIntersections TransitionsToIntersections);
        Task DeleteByIdIdAsync(int IntersectionID, int TransitionId);//מחיקה לפי מזהה סוג מיקום
    }
}
