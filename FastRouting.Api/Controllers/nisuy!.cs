using FastRouting.Common.DTO;
using FastRouting.Repositories.Interfaces;
using FastRouting.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FastRouting.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class nisuy_ : ControllerBase
    {

        private readonly ILocationsService _CoordinateService;

        public nisuy_(ILocationsService shoppingMallsServiece)
        {
            _CoordinateService = shoppingMallsServiece;
        }

        // GET: api/<nisuy_>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<nisuy_>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<nisuy_>
        [HttpPost]
        public async Task<bool> AddCoordy([FromBody] LocationsDTO item)
        {
            await _CoordinateService.AddAsync(item);
            return true;
        }

        // PUT api/<nisuy_>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<nisuy_>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
