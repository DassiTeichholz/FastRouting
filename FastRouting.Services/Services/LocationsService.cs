﻿using AutoMapper;
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
    public class LocationsService : ILocationsService
    {
        private readonly ILocationsRepository _LocationsRepository;
        private readonly IMapper _mapper;
        private readonly IEdgesService _edgesService;


        public LocationsService(ILocationsRepository LocationsRepository, IMapper mapper, IEdgesService edgesService)
        {
            _LocationsRepository = LocationsRepository;
            _mapper = mapper;
            _edgesService = edgesService;
        }

        public async Task<LocationsDTO> AddAsync(LocationsDTO Locations)
        {
            return _mapper.Map<LocationsDTO>(await _LocationsRepository.AddAsync(_mapper.Map<Location>(Locations)));

        }

        public async Task DeleteAsync(int Id)
        {
            await _LocationsRepository.DeleteAsync(Id);
        }

        public async Task<List<LocationsDTO>> GetAllAsync()
        {
            return _mapper.Map<List<LocationsDTO>>(await _LocationsRepository.GetAllAsync());

        }

        public async Task<LocationsDTO> GetByIDAsync(int ID)
        {
            return _mapper.Map<LocationsDTO>(await _LocationsRepository.GetByIDAsync(ID));

        }

        public async Task<LocationsDTO> UpdateAsync(LocationsDTO Locations)
        {
            return _mapper.Map<LocationsDTO>(await _LocationsRepository.UpdateAsync(_mapper.Map<Location>(Locations)));

        }

        public async Task<bool> CreateNewMall(List<LocationsDTO> locations, List<IntersectionsDTO> intersections, List<int>[] passCodes)
        {

            var x = Algorithm.AddMall(locations, intersections, passCodes);
            //add edges
            var res = await _edgesService.AddAsync(x);
            if (res == null)
            {
                return false;
            }
            return true;

        }
    }
}
