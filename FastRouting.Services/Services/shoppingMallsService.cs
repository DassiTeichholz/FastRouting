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
    public class shoppingMallsService : IshoppingMallsService
    {
        private readonly IshoppingMallsRepository _shoppingMallRepository;
        private readonly IMapper _mapper;
        private readonly IEdgesService _edgesService;
        //private readonly IEdgesService _edgesService;
        //private readonly IEdgesService _edgesService;
        //private readonly IEdgesService _edgesService;
        public shoppingMallsService(IshoppingMallsRepository shoppingMallRepository, IMapper mapper)
        {
            _shoppingMallRepository = shoppingMallRepository;
            _mapper = mapper;
        }

        public async Task<ShoppingMallsDTO> AddAsync(ShoppingMallsDTO shoppingMalls)
        {
            return _mapper.Map<ShoppingMallsDTO>(await _shoppingMallRepository.AddAsync(_mapper.Map<shoppingMalls>(shoppingMalls)));

        }

        public async Task DeleteAsync(int id)
        {
            await _shoppingMallRepository.DeleteAsync(id);
        }

        public async Task<List<ShoppingMallsDTO>> GetAllAsync()
        {
            return _mapper.Map<List<ShoppingMallsDTO>>(await _shoppingMallRepository.GetAllAsync());

        }

        public async Task<ShoppingMallsDTO> GetByIdAsync(int id)
        {
            return _mapper.Map<ShoppingMallsDTO>(await _shoppingMallRepository.GetByIdAsync(id));

        }

        public async Task<ShoppingMallsDTO> UpdateAsync(ShoppingMallsDTO shoppingMalls)
        {
            return _mapper.Map<ShoppingMallsDTO>(await _shoppingMallRepository.UpdateAsync(_mapper.Map<shoppingMalls>(shoppingMalls)));

        }

        public async Task<bool> CreateNewMall(List<LocationsDTO> locations, List<IntersectionsDTO> intersections, List<int>[] passCodes)
        {

            try
            {
                dynamic result = Algorithm.BuildingEdges(locations, intersections, passCodes);
                

                List<TransitionsToIntersectionsDTO> TransitionsToIntersections = result.TransitionsToIntersections;
                List<EdgesDTO> Edges = result.Edges;

                foreach (var item in TransitionsToIntersections)
                {


                }
                //add edges
                // var res = await _edgesService.AddAsync(x);
                //if (res == null)
                //{
                //    return false;
                //}
                return true;
            }
            catch (Exception ex) {
                return false;
            }
           

        }
    }
}
