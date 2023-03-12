using FastRouting.Common.DTO;
using FastRouting.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FastRouting.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class shoppingMallsController : ControllerBase
    {

        private readonly IshoppingMallsService _shoppingMallsServiece;

        public shoppingMallsController(IshoppingMallsService shoppingMallsServiece)
        {
            _shoppingMallsServiece = shoppingMallsServiece;
        }



        // GET: api/<shoppingMallsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<shoppingMallsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<shoppingMallsController>
        [HttpPost]
        //public bool AddCust([FromBody] List<dynamic> value)
        //{
        //    CustomersDTO c = value[1].ToObject<CustomersDTO>();
        //    var city = (string)value[0];
        //    return CustomersBLL.NewCust(c, city);

        //}
        //הפונקציה מוסיפה מרכז חדש, הפונקציה מקבלת:
        //שם המרכז החדש
        //ליסט של אובייקטים מטיפוס "תמונות של מרכז" המרכז החדש
        //ליסט של מיקומים
        //ליסט של נקודות הצטלבות
        //ליסט המעברים שמקביל לליט נקודות ההצטלבות
        //קשתות בעלות מרחק 0

        public async Task<bool> AddNewCenter([FromBody] List<dynamic> value)
        {
            string centerName= (string)value[0];
            var theMallPhotosDTOList= value[1].ToObject<List<TheMallPhotosDTO>>();
            var locationsList= value[2].ToObject<List<LocationsDTO>>();
            var IntersectionsList = value[3].ToObject<List<IntersectionsDTO>>();
            var passCodes = value[4].ToObject<List<int>[]>();
            var edgesCrossFloors = value[5].ToObject<List<object>>();


            return await _shoppingMallsServiece.CreateNewMall(centerName, theMallPhotosDTOList, locationsList, IntersectionsList, passCodes, edgesCrossFloors);
        }

        // PUT api/<shoppingMallsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<shoppingMallsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
