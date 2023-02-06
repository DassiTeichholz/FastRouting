using FastRouting.Common.DTO;
using FastRouting.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRouting.Services.Services
{
    internal class TheMallPhotosService : ITheMallPhotosService
    {
        public Task<TheMallPhotosRepositoryDTO> AddAsync(TheMallPhotosRepositoryDTO TheMallPhotosRepository)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TheMallPhotosRepositoryDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TheMallPhotosRepositoryDTO> GetByIDAsync(int ID)
        {
            throw new NotImplementedException();
        }

        public Task<TheMallPhotosRepositoryDTO> UpdateAsync(TheMallPhotosRepositoryDTO TheMallPhotosRepository)
        {
            throw new NotImplementedException();
        }
    }
}
