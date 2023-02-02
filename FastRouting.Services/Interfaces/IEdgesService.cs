using FastRouting.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRouting.Services.Interfaces
{
    public interface IEdgesService
    {
        Task<List<Edges>> GetAllAsync();
        Task<Edges> GetByIdAsync(int Id);
        Task<Edges> AddAsync(Edges Edges);
        Task<Edges> UpdateAsync(Edges Edges);
        Task DeleteAsync(int LocationIdA);
    }
}
