using FastRouting.Repositories.Interfaces;
using FastRouting.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FastRouting.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChangesAndUpdates : ControllerBase
    {
        private readonly ILocationsService _LocationsService;
        private readonly IIntersectionsRepository _IntersectionsRepository;
        // GET: api/<ChangesAndUpdates>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ChangesAndUpdates>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ChangesAndUpdates>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ChangesAndUpdates>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ChangesAndUpdates>/5
        [HttpDelete("{id}")]
        public async Task DeletingAlocation(int id)
        {
            _LocationsService.DeleteAsync(id);
            _IntersectionsRepository.DeleteAsync(id);




        }
    }
}
