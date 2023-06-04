using AutoMapper;
using FastRouting.Common.DTO;
using FastRouting.Repositories.Entities;
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
        public async Task<TheCenterPhotoDTO> AddAsync(TheCenterPhotoDTO TheCenterPhotoRepository)
        {
            return _mapper.Map<TheCenterPhotoDTO>(await _TheCenterPhotoRepository.AddAsync(_mapper.Map<TheCenterPhoto>(TheCenterPhotoRepository)));
        }

        public Task DeleteAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TheCenterPhotoDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
        public async Task<List<TheCenterPhotoDTO>> GetByZAsync(int z,int centerId)
        {
            return _mapper.Map<List<TheCenterPhotoDTO>>(await _TheCenterPhotoRepository.GetByZAsync(z, centerId));
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
