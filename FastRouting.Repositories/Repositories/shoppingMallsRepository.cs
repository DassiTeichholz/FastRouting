using FastRouting.Repositories.Entities;
using FastRouting.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRouting.Repositories.Repositories
{
    public class shoppingMallsRepository : IshoppingMallsRepository
    {
        public Task<shoppingMalls> AddAsync(shoppingMalls shoppingMalls)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<shoppingMalls>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<shoppingMalls> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<shoppingMalls> UpdateAsync(shoppingMalls shoppingMalls)
        {
            throw new NotImplementedException();
        }
    }
}
