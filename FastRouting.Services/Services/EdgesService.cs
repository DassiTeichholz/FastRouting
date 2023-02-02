using FastRouting.Repositories.Entities;
using FastRouting.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRouting.Services.Services
{
    internal class EdgesService : IEdgesService
    {
        public Task<Edges> AddAsync(Edges Edges)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int LocationIdA)
        {
            throw new NotImplementedException();
        }

        public Task<List<Edges>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Edges> GetByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Edges> UpdateAsync(Edges Edges)
        {
            throw new NotImplementedException();
        }
    }
}
