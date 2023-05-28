﻿using FastRouting.Common.DTO;
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

        // GET api/<nisuy_>/5
        //[HttpGet("{id}")]
        //public async Task<List<EdgesDTO>> Get(int id)
        //{
        //    return await _iEdgesService.GetByCenterIdAsync(id);
        //}
        //[HttpPost]
        //public IActionResult Post()
        //{
        //    int x = 5;
        //    // Handle the POST request
        //    return Ok("POST request received successfully");
        //}

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




        //[HttpPost]
        //public void Post([FromBody] JObject jsonObject)
        //{
        //    // Handle the JSON object received from the client
        //    // You can access the properties of the JObject using jsonObject.Property("propertyName").Value
        //}

        // POST api/<nisuy_>
        //[HttpPost("UploadData")]
        //public async Task<IActionResult> UploadData([FromForm] ImageUploadData uploadData)
        //{
        //    try
        //    {
        //        Perform actions with the received data
        //        List<Image> images = uploadData.Images;
        //        string inputString = uploadData.InputString;
        //        JObject jsonObject = uploadData.JsonObject;

        //        Additional logic...

        //        return Ok(); // or return any other appropriate response
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message); // or return any other appropriate error response
        //    }
        //}


        //public async Task<bool> AddCoordy2([FromBody] string flag)
        //{
        //    await _iEdgesService2.DataPreparationFunc(flag);
        //    return true;
        //}
        //public async Task<IActionResult> UploadData(ImageUploadData uploadData)
        //{
        //    if (uploadData == null)
        //    {
        //        return BadRequest("Invalid request data");
        //    }

        //    //// Access the images
        //    //List<string> images = uploadData.Images;
        //    //foreach (string imageData in images)
        //    //{
        //    //    // Process each image
        //    //    byte[] imageBytes = Convert.FromBase64String(imageData);

        //    //    // Perform any further processing with the image data
        //    //    // Example: Save each image to disk with a unique filename
        //    //    //string imagePath = $"path/to/save/image_{Guid.NewGuid()}.jpg";
        //    //    //await System.IO.File.WriteAllBytesAsync(imagePath, imageBytes);
        //    //}

        //    // Access the input string
        //    string inputString = uploadData.InputString;

        //    // Access the JSON object
        //    JObject jsonObject = uploadData.JsonObject;
        //    // Perform further operations with the JSON object

        //    return Ok();
        //}



        //public async Task<bool> Post()
        //{


        //    var formCollection = await Request.ReadFormAsync();

        //    // Access the images
        //    var images = formCollection.Files.GetFiles("image");
        //    foreach (var image in images)
        //    {
        //        if (image.Length == 0)
        //        {
        //            continue; // Skip empty files
        //        }

        //        // Process each uploaded image
        //        using (var memoryStream = new MemoryStream())
        //        {
        //            await image.CopyToAsync(memoryStream);
        //            byte[] imageData = memoryStream.ToArray();

        //            // Perform any further processing with the image data
        //            // Example: Save each image to disk with a unique filename
        //            string imagePath = $"path/to/save/image_{Guid.NewGuid()}.jpg";
        //            await System.IO.File.WriteAllBytesAsync(imagePath, imageData);
        //        }
        //    }

        //    // Access the input string
        //    var inputString = formCollection["inputString"];

        //    // Access the JSON object
        //    var jsonObject = formCollection["jsonObject"];
        //    // Parse the JSON object if needed

        //    // Perform further operations with the received data


        //    //var name = value[1].ToString();
        //    //var centerPList = new List<TheCenterPhotoDTO>();
        //    //foreach (var item in value[0])
        //    //{
        //    //    centerPList.Add(item);

        //    //}
        //    //var details=value[2].


        //    // טפל בנתונים המגיעים מהלקוח כאן
        //    // המידע מסוג JSON מגיע במשתנה jsonFile ויש להמיר אותו לאובייקט באמצעות JsonConvert.DeserializeObject
        //    // התמונות מגיעות ברשימה imagesArr ויש לטפל בהן כך שיוכלו להישמר במקום המתאים בשרת
        //    // לדוגמה, כדי להכניס אותן לתיקיית Images, ניתן להשתמש במקור הבא:
        //    // string imagePath = Path.Combine("Images", imagesArr[i].FileName);
        //    // using (var stream = new FileStream(imagePath, FileMode.Create))
        //    // {
        //    //    await imagesArr[i].CopyToAsync(stream);
        //    // }

        //    // החזר את התשובה המתאימה לפי הצורך
        //    return true; 
        //}
        //[FromBody] List<TheCenterPhotoDTO> TheCenterPhoto




        /*[FromForm] List<IFormFile> imagesArr, [FromForm] string centerName, [FromForm] string jsonFile*/

        //public async Task<bool> AddCoordy2([FromBody] LocationsDTO flag)
        //{
        //    await _iEdgesService2.AddAsync(flag);
        //    return true;
        //}

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
