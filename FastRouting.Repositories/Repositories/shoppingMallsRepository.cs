using FastRouting.Repositories.Entities;
using FastRouting.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRouting.Repositories.Repositories
{
    public class shoppingMallsRepository : IshoppingMallsRepository
    {
        private readonly IContext _context;
        public shoppingMallsRepository(IContext context)
        {
            _context = context;
        }

        public async Task<shoppingMalls> AddAsync(shoppingMalls shoppingMalls)
        {
            await _context.shoppingMalls.AddAsync(shoppingMalls);
            await _context.SaveChangesAsync();
            return shoppingMalls;
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
        public async Task<shoppingMalls> GetByNameAsync(string name)
        {
            return await _context.shoppingMalls.FirstOrDefaultAsync(x => x.Name == name);
        }

        public Task<shoppingMalls> UpdateAsync(shoppingMalls shoppingMalls)
        {
            throw new NotImplementedException();
        }
    }
}
