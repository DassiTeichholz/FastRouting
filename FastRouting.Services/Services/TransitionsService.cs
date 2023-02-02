using FastRouting.Repositories.Entities;
using FastRouting.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRouting.Services.Services
{
    internal class TransitionsService : ITransitionsService
    {
        public Task<Transitions> AddAsync(Transitions Transitions)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Transitions>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Transitions> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Transitions> UpdateAsync(Transitions Transitions)
        {
            throw new NotImplementedException();
        }
    }
}
