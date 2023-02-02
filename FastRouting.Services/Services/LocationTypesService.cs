using FastRouting.Repositories.Entities;
using FastRouting.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRouting.Services.Services
{
    internal class LocationTypesService : ILocationTypesService
    {
        public Task<LocationTypes> AddAsync(LocationTypes LocationTypes)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int locationTypeId)
        {
            throw new NotImplementedException();
        }

        public Task<List<LocationTypes>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<LocationTypes> GetByIdAsync(int locationTypeId)
        {
            throw new NotImplementedException();
        }

        public Task<LocationTypes> UpdateAsync(LocationTypes LocationTypes)
        {
            throw new NotImplementedException();
        }
    }
}
