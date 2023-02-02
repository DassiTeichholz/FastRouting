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
    public class LocationTypesRepository : ILocationTypesRepository
    {
        private readonly IContext _context;

        public async Task<LocationTypes> AddAsync(LocationTypes LocationTypes)
        {
            await _context.LocationTypes.AddAsync(LocationTypes);
            await _context.SaveChangesAsync();
            return LocationTypes;
        }

        public async Task DeleteAsync(int locationTypeId)
        {
            var locationTypes = await GetByIdAsync(locationTypeId);
            _context.LocationTypes.Remove(locationTypes);
            await _context.SaveChangesAsync();
        }

        public async Task<List<LocationTypes>> GetAllAsync()
        {
            return await _context.LocationTypes.ToListAsync();
        }

        public async Task<LocationTypes> GetByIdAsync(int locationTypeId)
        {
            return await _context.LocationTypes.FindAsync(locationTypeId);
        }

        public async Task<LocationTypes> UpdateAsync(LocationTypes LocationTypes)
        {
            var updatedLocationTypes = _context.LocationTypes.Update(LocationTypes);
            await _context.SaveChangesAsync();
            return updatedLocationTypes.Entity;
        }
    }
}
