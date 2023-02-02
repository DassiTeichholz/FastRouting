using FastRouting.Repositories.Entities;
using FastRouting.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRouting.Services.Services
{
    internal class TransitionsToIntersectionsServer : ITransitionsToIntersectionsService
    {
        public Task<TransitionsToIntersections> AddAsync(TransitionsToIntersections TransitionsToIntersections)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdIdAsync(int IntersectionID, int TransitionId)
        {
            throw new NotImplementedException();
        }

        public Task<List<TransitionsToIntersections>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TransitionsToIntersections> GetByIdIdAsync(int IntersectionID, int TransitionId)
        {
            throw new NotImplementedException();
        }

        public Task<TransitionsToIntersections> UpdateAsync(TransitionsToIntersections TransitionsToIntersections)
        {
            throw new NotImplementedException();
        }
    }
}
