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
    public class TransitionsRepository : ITransitionsRepository
    {
        private readonly IContext _context;

        public async Task<Transitions> AddAsync(Transitions Transitions)
        {
            await _context.Transitions.AddAsync(Transitions);
            await _context.SaveChangesAsync();
            return Transitions;
        }

        public async Task DeleteAsync(int id)
        {
            var transitions = await GetByIdAsync(id);
            _context.Transitions.Remove(transitions);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Transitions>> GetAllAsync()
        {
            return await _context.Transitions.ToListAsync();
        }

        public async Task<Transitions> GetByIdAsync(int id)
        {
            return await _context.Transitions.FindAsync(id);
        }

        public async Task<Transitions> UpdateAsync(Transitions Transitions)
        {
            var updatedTrasitions = _context.Transitions.Update(Transitions);
            await _context.SaveChangesAsync();
            return updatedTrasitions.Entity;
        }
    }
}
