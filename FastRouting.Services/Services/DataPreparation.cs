using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;


namespace FastRouting.Services.Services
{
    public class DataPreparation
    {
        //בעת הוספת מרכז חדש, הקונטרולר יפנה דבר ראשון לפונקציה הזו, שתפקידה לפרק את הקובץ ולהכינו להמשך
        //פונקציה זו תקבל:
        //json קובץ
        //סטים של תמונה וקומה , תמונה וקומה...
        public static void DataPreparationFunc()
        {
            string jsonString = File.ReadAllText("data.json");
            JObject jsonObject = JObject.Parse(jsonString);
            var locationInTrasition = jsonObject["locationInTrasition"];
            var edgesCrossing = jsonObject["edgesCrossing"];
            var intersection = jsonObject["intersection"];
            foreach (var item in locationInTrasition)
            {

            }
        }

        
    }
}
