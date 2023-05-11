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
    public class CentersRepository : ICentersRepository
    {
        private readonly IContext _context;
        public CentersRepository(IContext context)
        {
            _context = context;
        }

        public async Task<Centers> AddAsync(Centers Centers)
        {
            var c = _context.Centers.FirstOrDefault(x => x.name == "aa");
            await _context.Centers.AddAsync(Centers);
            await _context.SaveChangesAsync();
            return Centers;
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Centers>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Centers> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<Centers> GetByNameAsync(string name)
        {
            return await _context.Centers.FirstOrDefaultAsync(x => x.name == name);
        }

        public Task<Centers> UpdateAsync(Centers Centers)
        {
            throw new NotImplementedException();
        }
    }
}
