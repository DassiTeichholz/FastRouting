using AutoMapper;
using FastRouting.Common.DTO;
using FastRouting.Repositories.Interfaces;
using FastRouting.Repositories.Repositories;
using FastRouting.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRouting.Services.Services
{
    public class TheMallPhotosService : ITheMallPhotosService
    {
        private readonly ITheMallPhotosRepository _theMallPhotosRepository;
        private readonly IMapper _mapper;
        public TheMallPhotosService(ITheMallPhotosRepository theMallPhotosRepository, IMapper mapper)
        {
            _theMallPhotosRepository = theMallPhotosRepository;
            _mapper = mapper;
        }
        public Task<TheMallPhotosDTO> AddAsync(TheMallPhotosDTO TheMallPhotosRepository)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TheMallPhotosDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
        public async Task<List<TheMallPhotosDTO>> GetByZAsync(int z)
        {
            return _mapper.Map<List<TheMallPhotosDTO>>(await _theMallPhotosRepository.GetByZAsync(z));
        }

        public Task<TheMallPhotosDTO> GetByIDAsync(int ID)
        {
            throw new NotImplementedException();
        }

        public Task<TheMallPhotosDTO> UpdateAsync(TheMallPhotosDTO TheMallPhotosRepository)
        {
            throw new NotImplementedException();
        }
    }
}
