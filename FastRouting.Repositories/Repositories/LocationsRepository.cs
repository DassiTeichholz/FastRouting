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
    public class LocationsRepository : ILocationsRepository
    {
        private readonly IContext _context;

        public async Task<Locations> AddAsync(Locations Locations)
        {
            await _context.Locations.AddAsync(Locations);
            await _context.SaveChangesAsync();
            return Locations;
        }

        public async Task DeleteAsync(int Id)
        {
            var Locations = await GetByIDAsync(Id);
            _context.Locations.Remove(Locations);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Locations>> GetAllAsync()
        {
            return await _context.Locations.ToListAsync();
        }

        public async Task<Locations> GetByIDAsync(int ID)
        {
            return await _context.Locations.FindAsync(ID);
        }

        public async Task<Locations> UpdateAsync(Locations Locations)
        {
            var updatedLocation = _context.Locations.Update(Locations);
            await _context.SaveChangesAsync();
            return updatedLocation.Entity;
        }
    }
}
