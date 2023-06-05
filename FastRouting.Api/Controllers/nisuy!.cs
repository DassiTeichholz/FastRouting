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
//using System.Web.Script.Serialization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FastRouting.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class nisuy_ : ControllerBase
    {



        private readonly IIntersectionsService _iEdgesService;
        private readonly IAddingACenter _addingACenter;
        private readonly IRouteCalculation _routeCalculation;

        public nisuy_(IIntersectionsService CentersServiece, IAddingACenter addingACenter, IRouteCalculation routeCalculation)
        {
            _iEdgesService = CentersServiece;
            _addingACenter = addingACenter;
            _routeCalculation = routeCalculation;
        }

        // GET: api/<nisuy_>
        [HttpGet]
        public async Task<List<Floor>> Get(string nameSource, string nameDestination, int idCenter)
        {
            return await _routeCalculation.MainFunction(nameSource, nameDestination, idCenter);
        }

       
        //עובד מצוין!!!
        //[HttpPost]
        //public IActionResult Post([FromBody] string jsonPayload)
        //{
        //    // Parse the JSON string back to an object if needed
        //    var jsonObject = JsonConvert.DeserializeObject(jsonPayload);

        //    // Handle the JSON object as required

        //    return Ok("POST request received successfully");
        //}


        ////עובד מצוין!
        //[HttpPost]
        //public IActionResult Post([FromBody] List<Image> jsonPayload)
        //{
        //    // Parse the JSON string back to an object if needed
        // //   var jsonObject = JsonConvert.DeserializeObject(jsonPayload);

        //    // Handle the JSON object as required

        //    return Ok("POST request received successfully");
        //}



        [HttpPost]
        public async Task Post([FromBody] ImageUploadData image)
        {
            // Parse the JSON string back to an object if needed
            //   var jsonObject = JsonConvert.DeserializeObject(jsonPayload);

            // Handle the JSON object as required
            await _addingACenter.DataPreparationFunc(image.InputString,image.JsonObject,image.Images);
            
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
