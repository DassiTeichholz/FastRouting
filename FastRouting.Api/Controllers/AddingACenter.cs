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
    public class AddingACenter : ControllerBase
    {
        private readonly IIntersectionsService _intersectionsService;
        private readonly IAddingACenter _addingACenter;
        private readonly IRouteCalculation _routeCalculation;

        public AddingACenter(IIntersectionsService intersectionsService, IAddingACenter addingACenter, IRouteCalculation routeCalculation)
        {
            _intersectionsService = intersectionsService;
            _addingACenter = addingACenter;
            _routeCalculation = routeCalculation;
        }

        [HttpGet]
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
    }
}
