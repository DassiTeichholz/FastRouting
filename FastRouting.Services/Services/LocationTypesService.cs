using AutoMapper;
using FastRouting.Common.DTO;
using FastRouting.Repositories.Entities;
using FastRouting.Repositories.Interfaces;
using FastRouting.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRouting.Services.Services
{
    public class LocationTypesService : ILocationTypesService
    {
        private readonly ILocationTypesRepository _LocationTypesRepository;
        private readonly IMapper _mapper;
        public LocationTypesService(ILocationTypesRepository LocationTypesRepository, IMapper mapper)
        {
            _LocationTypesRepository = LocationTypesRepository;
            _mapper = mapper;
        }

        public async Task<LocationTypesDTO> AddAsync(LocationTypesDTO LocationTypes)
        {
            return _mapper.Map<LocationTypesDTO>(await _LocationTypesRepository.AddAsync(_mapper.Map<LocationTypes>(LocationTypes)));

        }

        public async Task DeleteAsync(int locationTypeId)
        {
            await _LocationTypesRepository.DeleteAsync(locationTypeId);
        }

        public async Task<List<LocationTypesDTO>> GetAllAsync()
        {
            return _mapper.Map<List<LocationTypesDTO>>(await _LocationTypesRepository.GetAllAsync());

        }

        public async Task<LocationTypesDTO> GetByIdAsync(int locationTypeId)
        {
            return _mapper.Map<LocationTypesDTO>(await _LocationTypesRepository.GetByIdAsync(locationTypeId));

        }

        public async Task<LocationTypesDTO> UpdateAsync(LocationTypesDTO LocationTypes)
        {
            return _mapper.Map<LocationTypesDTO>(await _LocationTypesRepository.UpdateAsync(_mapper.Map<LocationTypes>(LocationTypes)));

        }
    }
}
