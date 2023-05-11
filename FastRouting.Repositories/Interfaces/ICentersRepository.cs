using FastRouting.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRouting.Repositories.Interfaces
{
    public interface ICentersRepository
    {
        Task<List<Centers>> GetAllAsync();
        Task<Centers> GetByIdAsync(int id); 
        Task<Centers> GetByNameAsync(string name);
        Task<Centers> AddAsync(Centers Centers);
        Task<Centers> UpdateAsync(Centers Centers);
        Task DeleteAsync(int id);
    }
}
