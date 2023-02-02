using FastRouting.Common.DTO;
using FastRouting.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRouting.Services.Interfaces
{
    public interface ITransitionsToIntersectionsService
    {
        Task<List<TransitionsToIntersectionsDTO>> GetAllAsync();
        Task<TransitionsToIntersectionsDTO> GetByIdIdAsync(int IntersectionID, int TransitionId);
        Task<TransitionsToIntersectionsDTO> AddAsync(TransitionsToIntersectionsDTO TransitionsToIntersections);
        Task<TransitionsToIntersectionsDTO> UpdateAsync(TransitionsToIntersectionsDTO TransitionsToIntersections);
        Task DeleteByIdIdAsync(int IntersectionID, int TransitionId);//מחיקה לפי מזהה סוג מיקום
    }
}
