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
    public class EdgesRepository : IEdgesRepository
    {
        private readonly IContext _context;

        public async Task<Edges> AddAsync(Edges Edges)
        {
            await _context.Edges.AddAsync(Edges);
            await _context.SaveChangesAsync();
            return Edges;
        }

        public async Task DeleteAsync(int Id)
        {
            var Edges = await GetByIdAsync(Id);
            _context.Edges.Remove(Edges);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Edges>> GetAllAsync()
        {
            return await _context.Edges.ToListAsync();
        }

        public async Task<Edges> GetByIdAsync(int Id)
        {
            return await _context.Edges.FindAsync(Id);
        }

        public async Task<Edges> UpdateAsync(Edges Edges)
        {
            var Edge = _context.Edges.Update(Edges);
            await _context.SaveChangesAsync();
            return Edge.Entity;
        }
    }
}
