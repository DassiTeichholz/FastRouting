using FastRouting.Common.DTO;
using FastRouting.Repositories.Interfaces;
using FastRouting.Services.Interfaces;
using FastRouting.Services.Interfaces.ILogic;
using FastRouting.Services.Services;
using FastRouting.Services.Services.Logic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace FastRouting.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteCalculation : ControllerBase
    {
        private readonly IIntersectionsService _intersectionsService;
        private readonly IAddingACenter _addingACenter;
        private readonly IRouteCalculation _routeCalculation;
        private readonly ICentersService _centersService;
        private readonly ILocationsService _locationsService;

        public RouteCalculation(ILocationsService locationsService, ICentersService centersService, IIntersectionsService intersectionsService, IAddingACenter addingACenter, IRouteCalculation routeCalculation)
        {
            _locationsService= locationsService;
            _centersService = centersService;
            _intersectionsService = intersectionsService;
            _addingACenter = addingACenter;
            _routeCalculation = routeCalculation;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<List<Floor>> Get(string nameSource, string nameDestination, int idCenter)
        {
            return await _routeCalculation.MainFunction(nameSource, nameDestination, idCenter);
        }

        [HttpPost]
        public async Task Post([FromBody] ImageUploadData image)
        {
            await _addingACenter.DataPreparationFunc(image.InputString, image.JsonObject, image.Images);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            // Handle the PUT request
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            // Handle the DELETE request
        }

        [HttpGet]
        [Route("GetAllCenters")]

        public async Task<List<CentersDTO>> GetAllCenters()
        {
            // Logic to retrieve the desired resource
            // Example:
            List<CentersDTO> centers = await _centersService.GetAllAsync();

            return centers;
        }
        [HttpGet]
        [Route("GetLocations")]

        public async Task<List<LocationsDTO>> GetLocationsByCenterId(int centerId)
        {
            // Logic to retrieve the desired resource
            // Example:
            List<LocationsDTO> locations = await _locationsService.GetByCenterIdAsync(centerId);

            return locations;
        }
    }
}
