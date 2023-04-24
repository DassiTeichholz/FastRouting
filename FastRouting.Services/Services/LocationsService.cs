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
    public class LocationsService : ILocationsService
    {
        private readonly ILocationsRepository _LocationsRepository;
        private readonly IMapper _mapper;
        //private readonly IEdgesService _edgesService;
        //private readonly ILocationTypesService _locationTypesService;
        //private readonly ITransitionsService _transitionsService;


        public LocationsService(ILocationsRepository LocationsRepository, IMapper mapper, IEdgesService edgesService, ITransitionsService transitionsService, ILocationTypesService locationTypesService)
        {
            _LocationsRepository = LocationsRepository;
            _mapper = mapper;
            //_edgesService = edgesService;
            //_transitionsService = transitionsService;
            //_locationTypesService = locationTypesService;
        }

        public async Task<LocationsDTO> AddAsync(LocationsDTO Location)
        {
            //if (game.Subject == null)
            //{
            //    game.Subject =await _subjectService.GetByIdAsync(game.SubjectID);
            //}
            //if (Location.transitions == null)
            //{
            //    Location.transitions = await _transitionsService.GetByIdAsync(Location.transitionId);
            //}

            //if (Location.locationTypes == null)
            //{
            //    Location.locationTypes = await _locationTypesService.GetByIdAsync(Location.locationTypesId);
            //}
            return _mapper.Map<LocationsDTO>(await _LocationsRepository.AddAsync(_mapper.Map<Location>(Location)));

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
        public async Task<List<LocationsDTO>> GetByCenterIdAsync(int id)
        {
            return _mapper.Map<List<LocationsDTO>>(await _LocationsRepository.GetByCenterIdAsync(id));

        }
        public async Task<LocationsDTO> GetByNameAsync(string name)
        {
            return _mapper.Map<LocationsDTO>(await _LocationsRepository.GetByNameAsync(name));

        }


        public async Task<LocationsDTO> UpdateAsync(LocationsDTO Locations)
        {
            return _mapper.Map<LocationsDTO>(await _LocationsRepository.UpdateAsync(_mapper.Map<Location>(Locations)));

        }

        //public async Task<bool> CreateNewMall(List<LocationsDTO> locations, List<IntersectionsDTO> intersections, List<int>[] passCodes)
        //{

        //    var x = Algorithm.BuildingEdges(locations, intersections, passCodes);
        //    //add edges
        //   // var res = await _edgesService.AddAsync(x);
        //    //if (res == null)
        //    //{
        //    //    return false;
        //    //}
        //    return true;

        //}
    }
}
