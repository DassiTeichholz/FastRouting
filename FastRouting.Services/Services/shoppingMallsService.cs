using AutoMapper;
using FastRouting.Common.DTO;
using FastRouting.Repositories.Entities;
using FastRouting.Repositories.Interfaces;
using FastRouting.Repositories.Repositories;
using FastRouting.Services.Interfaces;
using FastRouting.Services.Services.Logic;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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


        //ניתוח הjson בלבד
        //public async Task DataPreparationFunc(string centerName)
        //{
        //    //הליסטים שיוחזרו בסוף, אחרי שננתח את הקובץ
        //    List<LocationsDTO> locationsList = new List<LocationsDTO>();
        //    List<IntersectionsDTO> intersectionsList = new List<IntersectionsDTO>();
        //    List<List<int>> passCodes = new List<List<int>>();




        //    string jsonString = File.ReadAllText("data.json");
        //    JObject jsonObject = JObject.Parse(jsonString);
        //    var locationsInTrasitions = jsonObject["locationInTrasition"];
        //    var edgesCrossing = jsonObject["edgesCrossing"];
        //    var intersections = jsonObject["intersection"];
        //    int num = 0;
        //    ShoppingMallsDTO shoppingMall = new ShoppingMallsDTO
        //    {

        //        Id=0,
        //        Name=centerName
        //    };
        //    ShoppingMallsDTO shoppingMall2= await AddAsync(shoppingMall);

        //    //עובר על כל מעבר ומוסיף 
        //    foreach (var item in locationsInTrasitions)
        //    {
        //        TransitionsDTO trasition = new TransitionsDTO
        //        {

        //            id=0,
        //            transitionsName= "trasition number "+num

        //        };
        //        TransitionsDTO transition = await _transitionsService.AddAsync(trasition);
        //        jsonObject["locationInTrasition"][num]["transitionId"]=transition.id;
        //        num++;
        //        var locations = item["locations"];
        //        foreach (var loc in locations)
        //        {
        //            LocationsDTO locationDTO = new LocationsDTO
        //            {

        //                id=0,
        //                coordinate= new CoordinateDTO
        //                {
        //                    id= 0,
        //                    x= (double)loc["coordinate"]["x"],
        //                    y= (double)loc["coordinate"]["y"],
        //                    z= (int)loc["coordinate"]["z"]
        //                },
        //                locationName=(string)loc["locationName"],
        //                transitionId=transition.id,
        //                transitions=null,
        //                locationTypesId=(int)loc["locationTypesId"],
        //                locationTypes=null,
        //                centerId=shoppingMall2.Id

        //            };
        //            locationsList.Add(locationDTO);
        //        }
        //    }
        //        // Convert the JObject to a JSON string
        //        jsonString = jsonObject.ToString();

        //        // Write the updated JSON string back to the file
        //        File.WriteAllText("data.json", jsonString);


        //         jsonString = File.ReadAllText("data.json");
        //         jsonObject = JObject.Parse(jsonString);
        //         locationsInTrasitions = jsonObject["locationInTrasition"];

        //        List<int> tmp = new List<int>();
        //        int x;
        //        int y;

        //        foreach (var intersec in intersections)
        //        {
        //            IntersectionsDTO intersection = new IntersectionsDTO
        //            {
        //                IntersectionID=0,
        //                Coordinate=new CoordinateDTO
        //                {
        //                    x= (double)intersec["coordinate"]["x"],
        //                    y= (double)intersec["coordinate"]["y"],
        //                    z= (int)intersec["coordinate"]["z"]
        //                },
        //                centerId=shoppingMall2.Id
        //            };
        //            intersectionsList.Add(intersection);
        //            var transitionsNums = intersec["transitionsNums"];
        //            foreach (var index in transitionsNums)
        //            {
        //                y = (int)index;
        //                x=(int)locationsInTrasitions[y]["transitionId"];
        //                tmp.Add(x);
        //            }
        //            passCodes.Add(tmp);
        //        }

        //    //טיפול בקשתות חוצות קומות
        //    // location קשתות חוצות קומות יכולות להיות רק בין שני אובייקטים מטיפוס 
        //    foreach (var edgeCrossing in edgesCrossing) 
        //    { 
              
        //    }

            




        //}

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

        //public async Task<bool> CreateNewMall(ShoppingMallsDTO shoppingMall, List<TheMallPhotosDTO> theMallPhotosDTOList,List<LocationsDTO> locations, List<IntersectionsDTO> intersections, List<List<int>> passCodes, List<dynamic> edgesCrossFloors)
        //{
        //    //מעברים יוצרים בצד לקוח!!!

        //    try
        //    {
        //        List<LocationsDTO> locations2 = new List<LocationsDTO>();
        //        List<IntersectionsDTO> intersections2 = new List<IntersectionsDTO>();
        //        //ShoppingMallsDTO shoppingMall = new ShoppingMallsDTO {
        //        //    Name=centerName
        //        //};
        //        //int shoppingMallId =  AddAsync(shoppingMall).Result.Id;
        //        foreach(var mallPhoto in theMallPhotosDTOList)
        //        {
        //           // mallPhoto.Id= shoppingMallId;
        //            await _theMallPhotosService.AddAsync(mallPhoto);
        //        }
        //        //מה בקשר לקאורדיננטה בעצמה?
        //        foreach (var location in locations)
        //        {
        //        //    location.centerId = shoppingMallId;
        //        //    if (location.transitions==null)
        //        //    {
        //        //        location.transitions=await _transitionsService.GetByIdAsync(location.transitionId);
        //        //    }
        //        //    if(location.locationTypes==null)
        //        //    {
        //        //        location.locationTypes=await _locationTypesService.GetByIdAsync(location.locationTypesId);
        //        //    }
        //            locations2.Add(await _LocationsService.AddAsync(location));
        //        }
        //        foreach(var intersection in intersections)
        //        {
        //        //    intersection.centerId = shoppingMallId;
        //            intersections2.Add( await _IntersectionsService.AddAsync(intersection));
        //        }
        //        dynamic result = Algorithm.BuildingEdges(locations2, intersections2, passCodes);
                

        //        List<TransitionsToIntersectionsDTO> TransitionsToIntersections = result.TransitionsToIntersections;
        //        List<EdgesDTO> Edges = result.Edges;

        //        foreach (var item in TransitionsToIntersections)
        //        {
        //            await _transitionsToIntersectionsService.AddAsync(item);
        //        }
        //        foreach (var edge in Edges)
        //        {
        //            edge.centerId = shoppingMall.Id;
        //            await _edgesService.AddAsync(edge);
        //        }
        //        int idA;
        //        int idB;
        //        foreach(var obj in edgesCrossFloors)
        //        {
        //            var location = await _LocationsService.GetByNameAsync(obj[0]);
        //            idA = location.Coordinate.Id;

        //            location = await _LocationsService.GetByNameAsync(obj[1]);
        //            idB = location.Coordinate.Id;
        //            EdgesDTO edge = new EdgesDTO
        //            {
        //                LocationIdA=idA,
        //                LocationIdB=idB,
        //                Distance=0

        //            };
        //            await _edgesService.AddAsync(edge);
        //        }

     
        //        return true;
        //    }
        //    catch (Exception ex) {
        //        return false;
        //    }
           

        //}
        //public async Task<List<VertexOfGraph>> GetRoute(string centerName, string sourceName, string DestName)
        //{
        //    try
        //    {
        //        int centerId = _shoppingMallRepository.GetByNameAsync(centerName).Id;
        //        List<EdgesDTO> edges;
        //        List<IntersectionsDTO> intersections;
        //        List<LocationsDTO> locations;
        //        edges = await _edgesService.GetByCenterIdAsync(centerId);
        //        intersections = await _IntersectionsService.GetBycenterIdAsync(centerId);
        //        locations = await _LocationsService.GetByCenterIdAsync(centerId);
        //        VertexOfGraph[] graph = Dijkstra.PreparingTheGraph(locations,intersections,edges);
        //        var location = await _LocationsService.GetByNameAsync(sourceName);
        //        int sourceNameId = location.coordinate.id;
        //        location = await _LocationsService.GetByNameAsync(DestName);
        //        int DestNameId = location.coordinate.id;
        //        List<VertexOfGraph> route = Dijkstra.DijkstraAlgorithm(sourceNameId, DestNameId, graph);
        //        return route;
                
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        

        //}

        //public async Task<bool> DeleteALocation(LocationsDTO location)
        //{
        //    try
        //    {
        //     var loc = await _LocationsService.GetByIDAsync(location.id);
        //     int centerId = loc.centerId;
        //     List<EdgesDTO> edges = await _edgesService.GetByCenterIdAsync(centerId);
        //     foreach (EdgesDTO edge in edges)
        //        {
        //            if (edge.LocationIdA==location.coordinate.id||edge.LocationIdB==location.coordinate.id)
        //            {
        //                await _edgesService.DeleteAsync(edge.LocationIdA);
        //            }
        //        }

        //     //if the trasition of the location is unusing- delete its!
        //     return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}
    }
}
