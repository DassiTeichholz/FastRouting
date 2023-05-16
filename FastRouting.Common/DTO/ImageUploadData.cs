using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FastRouting.Common.DTO
{
    public class ImageUploadData
    {
        public List<string> Images { get; set; }
        public string InputString { get; set; }
        public JObject JsonObject { get; set; }
    }

}
