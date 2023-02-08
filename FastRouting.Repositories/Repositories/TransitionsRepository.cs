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

        public async Task<Transition> AddAsync(Transition Transitions)
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

        public async Task<List<Transition>> GetAllAsync()
        {
            return await _context.Transitions.ToListAsync();
        }

        public async Task<Transition> GetByIdAsync(int id)
        {
            return await _context.Transitions.FindAsync(id);
        }

        public async Task<Transition> UpdateAsync(Transition Transitions)
        {
            var updatedTrasitions = _context.Transitions.Update(Transitions);
            await _context.SaveChangesAsync();
            return updatedTrasitions.Entity;
        }
    }
}
