using FastRouting.Common.DTO;
using FastRouting.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRouting.Services.Interfaces
{
    public interface IIntersectionsService
    {
        Task<List<IntersectionsDTO>> GetAllAsync();
        Task<IntersectionsDTO> GetByIdAsync(int IntersectionID);
        Task<List<IntersectionsDTO>> GetBycenterIdAsync(int id);
        Task<IntersectionsDTO> AddAsync(IntersectionsDTO Intersections);
        Task<IntersectionsDTO> UpdateAsync(IntersectionsDTO Intersections);
        Task DeleteAsync(int IntersectionID);//מחיקה לפי מזהה הצטלבות
        Task Bla(bool flag);

    }
}
