using FastRouting.Common.DTO;
using FastRouting.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRouting.Services.Services
{
    internal class CoordinateService : ICoordinateDTOService
    {
        public Task<CoordinateDTO> AddAsync(CoordinateDTO CoordinateDTO)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CoordinateDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CoordinateDTO> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CoordinateDTO> UpdateAsync(CoordinateDTO CoordinateDTO)
        {
            throw new NotImplementedException();
        }
    }
}
