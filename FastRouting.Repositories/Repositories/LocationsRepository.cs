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
        public LocationsRepository(IContext context)
        {
            _context = context;
        }

        public async Task<Location> AddAsync(Location Location)
        {
            
            if(Location.transitions != null)
            {
                _context.Transitions.Attach(Location.transitions);
            }
            if(Location.locationTypes != null)
            {
                _context.LocationTypes.Attach(Location.locationTypes);
            }



            await _context.Locations.AddAsync(Location);
            await _context.SaveChangesAsync();
            return Location;
        }

        public async Task DeleteAsync(int Id)
        {
            var Locations = await GetByIDAsync(Id);
            _context.Locations.Remove(Locations);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Location>> GetAllAsync()
        {
            return await _context.Locations.ToListAsync();
        }

        public async Task<Location> GetByIDAsync(int ID)
        {
            return await _context.Locations.FindAsync(ID);
        }
        public async Task<List<Location>> GetByCenterIdAsync(int id)
        {
            return await _context.Locations.Where(x=>x.centerId==id).ToListAsync();
        }
          public async Task<Location> GetByNameAsync(string name)
        {
            return await  _context.Locations/*.Include(x=>x.Coordinate)*/.FirstOrDefaultAsync(x=>x.locationName==name);
        }

        public async Task<Location> UpdateAsync(Location Locations)
        {
            var updatedLocation = _context.Locations.Update(Locations);
            await _context.SaveChangesAsync();
            return updatedLocation.Entity;
        }
    }
}
