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
    public class TheCenterPhotoService : ITheCenterPhotoService
    {
        private readonly ITheCenterPhotoRepository _TheCenterPhotoRepository;
        private readonly IMapper _mapper;
        public TheCenterPhotoService(ITheCenterPhotoRepository TheCenterPhotoRepository, IMapper mapper)
        {
            _TheCenterPhotoRepository = TheCenterPhotoRepository;
            _mapper = mapper;
        }
        public Task<TheCenterPhotoDTO> AddAsync(TheCenterPhotoDTO TheCenterPhotoRepository)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TheCenterPhotoDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
        public async Task<List<TheCenterPhotoDTO>> GetByZAsync(int z)
        {
            return _mapper.Map<List<TheCenterPhotoDTO>>(await _TheCenterPhotoRepository.GetByZAsync(z));
        }

        public Task<TheCenterPhotoDTO> GetByIDAsync(int ID)
        {
            throw new NotImplementedException();
        }

        public Task<TheCenterPhotoDTO> UpdateAsync(TheCenterPhotoDTO TheCenterPhotoRepository)
        {
            throw new NotImplementedException();
        }
    }
}
