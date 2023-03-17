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
        private readonly ILocationsService _LocationsService;
        private readonly IIntersectionsService _IntersectionsService;
        private readonly ITheMallPhotosService _theMallPhotosService;
        private readonly IMapper _mapper;
        private readonly IEdgesService _edgesService;
        private readonly ITransitionsService _transitionsService;
        private readonly ILocationTypesService _locationTypesService;
        private readonly ITransitionsToIntersectionsService _transitionsToIntersectionsService;
        public shoppingMallsService(IshoppingMallsRepository shoppingMallRepository, IMapper mapper, ITheMallPhotosService theMallPhotosService, IIntersectionsService intersectionsService, ILocationsService locationsService, ITransitionsService transitionsService, ILocationTypesService locationTypesService, ITransitionsToIntersectionsService transitionsToIntersectionsService)
        {
            _shoppingMallRepository = shoppingMallRepository;
            _mapper = mapper;
            _theMallPhotosService=theMallPhotosService;
            _IntersectionsService=intersectionsService;
            _LocationsService=locationsService;
            _transitionsService=transitionsService;
            _locationTypesService=locationTypesService;
            _transitionsToIntersectionsService=transitionsToIntersectionsService;
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
        public async Task<ShoppingMallsDTO> GetByNameAsync(string name)
        {
            return _mapper.Map<ShoppingMallsDTO>(await _shoppingMallRepository.GetByNameAsync(name));

        }

        public async Task<ShoppingMallsDTO> UpdateAsync(ShoppingMallsDTO shoppingMalls)
        {
            return _mapper.Map<ShoppingMallsDTO>(await _shoppingMallRepository.UpdateAsync(_mapper.Map<shoppingMalls>(shoppingMalls)));

        }

        public async Task<bool> CreateNewMall(string centerName, List<TheMallPhotosDTO> theMallPhotosDTOList,List<LocationsDTO> locations, List<IntersectionsDTO> intersections, List<int>[] passCodes, List<dynamic> edgesCrossFloors)
        {

            try
            {
                List<LocationsDTO> locations2 = new List<LocationsDTO>();
                List<IntersectionsDTO> intersections2 = new List<IntersectionsDTO>();
                ShoppingMallsDTO shoppingMall = new ShoppingMallsDTO {
                    Name=centerName
                };
                int shoppingMallId =  AddAsync(shoppingMall).Result.Id;
                foreach(var mallPhoto in theMallPhotosDTOList)
                {
                    mallPhoto.Id= shoppingMallId;
                    await _theMallPhotosService.AddAsync(mallPhoto);
                }
                //מה בקשר לקאורדיננטה בעצמה?
                foreach (var location in locations)
                {
                    location.centerId = shoppingMallId;
                    if (location.Transitions==null)
                    {
                        location.Transitions=await _transitionsService.GetByIdAsync(location.TransitionId);
                    }
                    if(location.LocationTypes==null)
                    {
                        location.LocationTypes=await _locationTypesService.GetByIdAsync(location.LocationTypesId);
                    }
                    locations2.Add(await _LocationsService.AddAsync(location));
                }
                foreach(var intersection in intersections)
                {
                    intersection.centerId = shoppingMallId;
                    intersections2.Add( await _IntersectionsService.AddAsync(intersection));
                }
                dynamic result = Algorithm.BuildingEdges(locations2, intersections2, passCodes);
                

                List<TransitionsToIntersectionsDTO> TransitionsToIntersections = result.TransitionsToIntersections;
                List<EdgesDTO> Edges = result.Edges;

                foreach (var item in TransitionsToIntersections)
                {
                    await _transitionsToIntersectionsService.AddAsync(item);
                }
                foreach (var edge in Edges)
                {
                    edge.centerId = shoppingMallId;
                    await _edgesService.AddAsync(edge);
                }
                int idA;
                int idB;
                foreach(var obj in edgesCrossFloors)
                {
                    var location = await _LocationsService.GetByNameAsync(obj[0]);
                    idA = location.Coordinate.Id;

                    location = await _LocationsService.GetByNameAsync(obj[1]);
                    idB = location.Coordinate.Id;
                    EdgesDTO edge = new EdgesDTO
                    {
                        LocationIdA=idA,
                        LocationIdB=idB,
                        Distance=0

                    };
                    await _edgesService.AddAsync(edge);
                }

     
                return true;
            }
            catch (Exception ex) {
                return false;
            }
           

        }
        public async Task<List<VertexOfGraph>> GetRoute(string centerName, string sourceName, string DestName)
        {
            try
            {
                int centerId = _shoppingMallRepository.GetByNameAsync(centerName).Id;
                List<EdgesDTO> edges;
                List<IntersectionsDTO> intersections;
                List<LocationsDTO> locations;
                edges = await _edgesService.GetByCenterIdAsync(centerId);
                intersections = await _IntersectionsService.GetBycenterIdAsync(centerId);
                locations = await _LocationsService.GetByCenterIdAsync(centerId);
                VertexOfGraph[] graph = Dijkstra.PreparingTheGraph(locations,intersections,edges);
                var location = await _LocationsService.GetByNameAsync(sourceName);
                int sourceNameId = location.Coordinate.Id;
                location = await _LocationsService.GetByNameAsync(DestName);
                int DestNameId = location.Coordinate.Id;
                List<VertexOfGraph> route = Dijkstra.DijkstraAlgorithm(sourceNameId, DestNameId, graph);
                return route;
                
            }
            catch (Exception ex)
            {
                return null;
            }
        

        }

        public async Task<bool> DeleteALocation(LocationsDTO location)
        {
            try
            {
             var loc = await _LocationsService.GetByIDAsync(location.Id);
             int centerId = loc.centerId;
             List<EdgesDTO> edges = await _edgesService.GetByCenterIdAsync(centerId);
             foreach (EdgesDTO edge in edges)
                {
                    if (edge.LocationIdA==location.Coordinate.Id||edge.LocationIdB==location.Coordinate.Id)
                    {
                        await _edgesService.DeleteAsync(edge.LocationIdA);
                    }
                }

             //if the trasition of the location is unusing- delete its!
             return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
