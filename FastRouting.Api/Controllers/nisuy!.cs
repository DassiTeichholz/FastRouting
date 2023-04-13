using FastRouting.Common.DTO;
using FastRouting.Repositories.Interfaces;
using FastRouting.Services.Interfaces;
using FastRouting.Services.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FastRouting.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class nisuy_ : ControllerBase
    {

       

        private readonly IIntersectionsService _iEdgesService;

        public nisuy_(IIntersectionsService shoppingMallsServiece)
        {
            _iEdgesService = shoppingMallsServiece;
        }

        // GET: api/<nisuy_>
        [HttpGet]
        //public async Task<List<EdgesDTO>> Get()
        //{
        //    return await _iEdgesService.GetAllAsync();
        //}

        // GET api/<nisuy_>/5
        [HttpGet("{id}")]
        //public  async Task<List<EdgesDTO>> Get(int id)
        //{
        //    return await _iEdgesService.GetByCenterIdAsync(id);
        //}

        // POST api/<nisuy_>
        [HttpPost]
        public async Task<bool> AddCoordy([FromBody] List<int>[] item)
        {
           // await _iEdgesService.AddAsync(item);
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
