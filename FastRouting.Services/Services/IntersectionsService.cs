using FastRouting.Repositories.Entities;
using FastRouting.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRouting.Services.Services
{
    internal class IntersectionsService : IIntersectionsService
    {
        public Task<Intersections> AddAsync(Intersections Intersections)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int IntersectionID)
        {
            throw new NotImplementedException();
        }

        public Task<List<Intersections>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Intersections> GetByIdAsync(int IntersectionID)
        {
            throw new NotImplementedException();
        }

        public Task<Intersections> UpdateAsync(Intersections Intersections)
        {
            throw new NotImplementedException();
        }
    }
}
