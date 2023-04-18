﻿using FastRouting.Common.DTO;
using FastRouting.Services.Interfaces;
using FastRouting.Services.Services;
using FastRouting.Services.Services.Logic;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FastRouting.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class shoppingMallsController : ControllerBase
    {

        private readonly ILocationsService _shoppingMallsServiece;

        public shoppingMallsController(ILocationsService shoppingMallsServiece)
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
        public List<VertexOfGraph> GetRoute(string centerName,string sourceName, string DestinationName)
        {

            return null;
        }

        // POST api/<shoppingMallsController>
        [HttpPost]
        public async Task<bool> AddCust([FromBody] LocationsDTO value)
        {
            await _shoppingMallsServiece.AddAsync(value);
            return true;

        }
        //הפונקציה מוסיפה מרכז חדש, הפונקציה מקבלת:
        //שם המרכז החדש
        //ליסט של אובייקטים מטיפוס "תמונות של מרכז" המרכז החדש
        //ליסט של מיקומים
        //ליסט של נקודות הצטלבות
        //ליסט המעברים שמקביל לליט נקודות ההצטלבות
        //קשתות בעלות מרחק 0

        //public async Task<bool> AddNewCenter(List<dynamic> value,List<LocationsDTO> value2)
        //    {
        //    string centerName = value[0].ToString();

        //    var theMallPhotosDTOList = value[1];

        //    var locationsList = value[2].ToObject<LocationsDTO>();
        //    var IntersectionsList = value[3].ToObject<List<IntersectionsDTO>>();

        //    var passCodes = value[4].toObject<List<List<int>>>();
        //    var edgesCrossFloors = value[5];

        //    //string centerName=value[0].ToString();
        //    //var theMallPhotosDTOList= value[1].ToObject<List<TheMallPhotosDTO>>();
        //    //var locationsList= value[2].ToObject<List<LocationsDTO>>();
        //    //var IntersectionsList = value[3].ToObject<List<IntersectionsDTO>>();
        //    //var passCodes = value[4].ToObject<List<int>[]>();
        //    //  var edgesCrossFloors = value[5].ToObject<List<dynamic>>();



        //    return await _shoppingMallsServiece.CreateNewMall(centerName, theMallPhotosDTOList, locationsList, IntersectionsList, passCodes, edgesCrossFloors);
        //}

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
