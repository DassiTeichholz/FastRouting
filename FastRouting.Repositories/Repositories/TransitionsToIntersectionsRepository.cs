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
    public class TransitionsToIntersectionsRepository : ITransitionsToIntersectionsRepository
    {
        private readonly IContext _context;

        public async Task<TransitionsToIntersections> AddAsync(TransitionsToIntersections TransitionsToIntersections)
        {
            await _context.TransitionsToIntersections.AddAsync(TransitionsToIntersections);
            await _context.SaveChangesAsync();
            return TransitionsToIntersections;
        }

        public async Task DeleteByIdIdAsync(int IntersectionID, int TransitionId)
        {
            var role = await GetByIdIdAsync(IntersectionID, TransitionId);
            _context.TransitionsToIntersections.Remove(role);
            await _context.SaveChangesAsync();
        }

        public async Task<List<TransitionsToIntersections>> GetAllAsync()
        {
            return await _context.TransitionsToIntersections.ToListAsync();
        }

        public async Task<TransitionsToIntersections> GetByIdIdAsync(int IntersectionID, int TransitionId)
        {
            return await _context.TransitionsToIntersections.FindAsync(IntersectionID, TransitionId);
        }

        public async Task<TransitionsToIntersections> UpdateAsync(TransitionsToIntersections TransitionsToIntersections)
        {
            var updatedT = _context.TransitionsToIntersections.Update(TransitionsToIntersections);
            await _context.SaveChangesAsync();
            return updatedT.Entity;
        }
    }
}
