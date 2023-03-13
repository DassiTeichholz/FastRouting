using FastRouting.Common.DTO;
using FastRouting.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FastRouting.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConstructionOfANewCenter : ControllerBase
    {
        private readonly IshoppingMallsService _shoppingMallsService;
        // GET: api/<ConstructionOfANewCenter>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ConstructionOfANewCenter>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ConstructionOfANewCenter>
        [HttpPost]
        //יש להתייחס גם לתמונה!
        public async Task<bool> CreateNewMall([FromBody] List<dynamic> value)
        {
            List<LocationsDTO> locations = value[0].ToObject<List<LocationsDTO>>();
            List<IntersectionsDTO> intersections = value[1].ToObject<List<IntersectionsDTO>>();
            List<int>[] passCodes = value[2].ToObject<List<int>[]>();
            // var flag = await _shoppingMallsService.CreateNewMall(locations, intersections, passCodes);
            //return flag;
            return true; 
        }

        // PUT api/<ConstructionOfANewCenter>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ConstructionOfANewCenter>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
