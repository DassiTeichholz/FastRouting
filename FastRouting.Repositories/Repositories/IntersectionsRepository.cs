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
    public class IntersectionsRepository : IIntersectionsRepository
    {
        private readonly IContext _context;
        public IntersectionsRepository(IContext context)
        {
            _context = context;
        }

        public async Task<Intersections> AddAsync(Intersections Intersections)
        {
            await _context.Intersections.AddAsync(Intersections);
            await _context.SaveChangesAsync();
            return Intersections;
        }

        public async Task DeleteAsync(int IntersectionID)
        {
            var intersections = await GetByIdAsync(IntersectionID);
            _context.Intersections.Remove(intersections);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Intersections>> GetAllAsync()
        {
            return await _context.Intersections.ToListAsync();
        }

        public async Task<Intersections> GetByIdAsync(int IntersectionID)
        {
            return await _context.Intersections.FindAsync(IntersectionID);
        }
         public async Task<List<Intersections>> GetBycenterIdAsync(int id)
        {
            return await _context.Intersections.Include(c=>c.Coordinate).Where(x=>x.centerId==id).ToListAsync();
        }

        public async Task<Intersections> UpdateAsync(Intersections Intersections)
        {
            var updatedIntrsection = _context.Intersections.Update(Intersections);
            await _context.SaveChangesAsync();
            return updatedIntrsection.Entity;
        }
    }
}
