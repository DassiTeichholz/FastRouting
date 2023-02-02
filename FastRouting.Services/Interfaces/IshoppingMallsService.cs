using FastRouting.Common.DTO;
using FastRouting.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRouting.Services.Interfaces
{
    public interface IshoppingMallsService
    {
        Task<List<ShoppingMallsDTO>> GetAllAsync();
        Task<ShoppingMallsDTO> GetByIdAsync(int id);
        Task<ShoppingMallsDTO> AddAsync(ShoppingMallsDTO shoppingMalls);
        Task<ShoppingMallsDTO> UpdateAsync(ShoppingMallsDTO shoppingMalls);
        Task DeleteAsync(int id);
    }
}
