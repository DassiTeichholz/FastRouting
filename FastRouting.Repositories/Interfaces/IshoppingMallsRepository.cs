using FastRouting.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRouting.Repositories.Interfaces
{
    public interface IshoppingMallsRepository
    {
        Task<List<shoppingMalls>> GetAllAsync();
        Task<shoppingMalls> GetByIdAsync(int id);
        Task<shoppingMalls> AddAsync(shoppingMalls shoppingMalls);
        Task<shoppingMalls> UpdateAsync(shoppingMalls shoppingMalls);
        Task DeleteAsync(int id);
    }
}
