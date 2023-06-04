using AutoMapper;
using FastRouting.Common.DTO;
using FastRouting.Repositories.Entities;
using FastRouting.Repositories.Interfaces;
using FastRouting.Services.Interfaces;
using FastRouting.Services.Interfaces.ILogic;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRouting.Services.Services.Logic
{
    public class AddingACenter : IAddingACenter
    {

        private readonly ICentersService _Centerservice;
        private readonly ILocationsService _LocationsService;
        private readonly IIntersectionsService _IntersectionsService;
        private readonly ITheCenterPhotoService _TheCenterPhotoService;
        private readonly IMapper _mapper;
        private readonly IEdgesService _edgesService;
        private readonly ITransitionsService _transitionsService;
        private readonly ILocationTypesService _locationTypesService;
        private readonly ITransitionsToIntersectionsService _transitionsToIntersectionsService;
        public AddingACenter(IMapper mapper, ICentersService Centerservice, IEdgesService edgesService, ITheCenterPhotoService TheCenterPhotoService, IIntersectionsService intersectionsService, ILocationsService locationsService, ITransitionsService transitionsService, ILocationTypesService locationTypesService, ITransitionsToIntersectionsService transitionsToIntersectionsService)
        {
            _mapper = mapper;
            _Centerservice = Centerservice;
            _edgesService = edgesService;
            _TheCenterPhotoService = TheCenterPhotoService;
            _IntersectionsService = intersectionsService;
            _LocationsService = locationsService;
            _transitionsService = transitionsService;
            _locationTypesService = locationTypesService;
            _transitionsToIntersectionsService = transitionsToIntersectionsService;
        }
        



        //פונקציה זו מכינה את הנתונים,
        //היא עוברת על קובץ הג'ייסון, ומכינה מהם אובייקטים של נקודות מעבר ונקודות הצטלבות
        public async Task DataPreparationFunc(string centerName,string jsonString,List<Image>images)
        {
            //הליסטים שיוחזרו בסוף, אחרי שננתח את הקובץ
            List<LocationsDTO> locationsList = new List<LocationsDTO>();
            List<IntersectionsDTO> intersectionsList = new List<IntersectionsDTO>();
            //ליסט זה, מקביל לליסט נקודות ההצטלבות, כל איבר בו הוא ליסט בעצמו, 
            //לדוגמא, הליסט שנמצא באינדקס 0 מכיל את מזהי נקודות המעבר
            //שנקודת ההצטלבות שנמצאת באינדקס 0 בליסט ההצטלבויות, נמצאת בתוכם
            List<List<int>> passCodes = new List<List<int>>();
            string centerName2 = centerName.Replace(" ", "");

            string fileName = centerName2+"Data"+".json";

            //jsonString = jsonString.Trim();
            //jsonString = jsonString.Replace("\r", "").Replace("\n", "");
            //jsonString = jsonString.Replace("\\r", "").Replace("\\n", "");
            string cleanedJsonString = jsonString.Replace("/[\n\r\t]+/", "");
            cleanedJsonString = jsonString.Replace("\r\n", "").Replace("\n", "").Replace("\r", "");
            // cleanedJsonString = jsonString.Replace("\"", "");

            //cleanedJsonString = string.Join("\n", jsonString.Split('\n').Select(line => line.TrimStart().TrimEnd()));
            // Remove comments (optional)
            // Here's a simple example that removes single-line comments starting with '//'
            // jsonString = System.Text.RegularExpressions.Regex.Replace(jsonString, @"//.*", "");
            //JObject jsonObject = JsonConvert.DeserializeObject<JObject>(cleanedJsonString);

            JObject jsonObject = JObject.Parse(cleanedJsonString);
            //jsonString = jsonObject.ToString();
            File.WriteAllText(fileName, jsonString);
            //// Remove the extra wrapping from the JSON string
            //string cleanedJsonString = jsonString.Trim('"');

            //// Deserialize the JSON string to a dynamic object
            //dynamic jsonObject2 = JsonConvert.DeserializeObject(cleanedJsonString);

            //// Convert the dynamic object back to a JSON string
            //string formattedJsonString = JsonConvert.SerializeObject(jsonObject2, Formatting.Indented);

            //File.WriteAllText(fileName, formattedJsonString);
            //string jsonString = File.ReadAllText(fileName);
            //נקודות המיקום במרכז
            int xx = 55;
            var locationsInTrasitions = jsonObject["locationInTrasition"];
            //קשתות חוצות קומות במרכז
            var edgesCrossing = jsonObject["edgesCrossing"];
            //נקודות הצטלבות במרכז
            var intersections = jsonObject["intersection"];
            int num = 0;
            //ראשית נוסיף את המרכז החדש למערכת
            CentersDTO shoppingMall = new CentersDTO
            {

                shoppingMallId = 0,
                Name = centerName
            };
            CentersDTO shoppingMall2 = await _Centerservice.AddAsync(shoppingMall);

            //עובר על כל מעבר במרכז  
            foreach (var item in locationsInTrasitions)
            {
                //ראשית יוצר מעבר חדש
                TransitionsDTO trasition = new TransitionsDTO
                {

                    trasitionId = 0,
                    transitionsName = "trasition number " + num

                };
                //db מוסיף את המעבר החדש ל
                TransitionsDTO transition = await _transitionsService.AddAsync(trasition);
                //מעדכן את קוד המעבר בג'ייסון, לקוד המעבר האמיתי , עד עכשיו קוד המעבר היה 0
                jsonObject["locationInTrasition"][num]["transitionId"] = transition.trasitionId;
                num++;
                //שולף את נקודות המיקום שנמצאות במעבר הנוכחי
                var locations = item["locations"];
                foreach (var loc in locations)
                {
                    //יוצר אובייקט מיקום מכל נקודת מיקום במעבר
                    LocationsDTO locationDTO = new LocationsDTO
                    {

                        locationId = 0,
                        coordinate = new CoordinateDTO
                        {
                            coordinateId = 0,
                            x = (double)loc["coordinate"]["x"],
                            y = (double)loc["coordinate"]["y"],
                            z = (int)loc["coordinate"]["z"]
                        },
                        locationName = (string)loc["locationName"],
                        transitionId = transition.trasitionId,
                        transitions = null,
                        locationTypesId = (int)loc["locationTypesId"],
                        locationTypes = null,
                        centerId = shoppingMall2.shoppingMallId

                    };
                    //מוסיף את האובייקט החדש לליסט נקודות המיקום
                    locationsList.Add(locationDTO);
                }
            }
            //JObject ממיר את
            //JSON string לסוג טיפוס
            jsonString = jsonObject.ToString();

            // נעשו שינויים בקובץ הג'ייסון, מעדכן את השינויים
            File.WriteAllText(fileName, jsonString);
            //קורא את קובץ הג'ייסון שנית
            jsonString = File.ReadAllText(fileName);
            jsonObject = JObject.Parse(jsonString);
            locationsInTrasitions = jsonObject["locationInTrasition"];

            List<int> tmp = new List<int>();
            int x;
            int y;
            //עובר על כל נקודות ההצטלבות שבקובץ הג'ייסון
            foreach (var intersec in intersections)
            {
                //יוצר נקודת הצטלבות חדשה
                IntersectionsDTO intersection = new IntersectionsDTO
                {
                    intersectionId = 0,
                    coordinate = new CoordinateDTO
                    {
                        x = (double)intersec["coordinate"]["x"],
                        y = (double)intersec["coordinate"]["y"],
                        z = (int)intersec["coordinate"]["z"]
                    },
                    centerId = shoppingMall2.shoppingMallId,
                    IntersectionOnLocation=(bool)intersec["IntersectionOnLocation"]
                };
                //מוסיף את האובייקט החדש לליסט נקודות ההצטלבות
                intersectionsList.Add(intersection);
                //מערך זה מבטא את האינדקסים של המעברים בקובץ הג'ייסון, בהם נמצאת נקודת ההצטלבות
                var transitionsNums = intersec["transitionsNums"];
                foreach (var index in transitionsNums)
                {
                    y = (int)index;
                    x = (int)locationsInTrasitions[y]["transitionId"];
                    tmp.Add(x);
                }
                //מוסיפים לנקודת ההצטלבות את הליסט המכיל מזהי מעבר שנקודת ההצטלבות נמצאת בתוכם
                passCodes.Add(tmp);
                tmp= new List<int>();
            }

            //טיפול בקשתות חוצות קומות
            // location קשתות חוצות קומות יכולות להיות רק בין שני אובייקטים מטיפוס 
            //foreach (var edgeCrossing in edgesCrossing)
            //{

            //}


            //מה שנשאר לעשות כאן:
            //ליצור אובייקטים של קשתות
            //ליצור אובייקטים של תמונות
            string base64Data;
            byte[] imageBytes;
            List<TheCenterPhotoDTO>centerPhotoDTOs= new List<TheCenterPhotoDTO>();

            foreach (var image in images)
            {
                base64Data = (image.image).Substring((image.image).IndexOf(',') + 1);
                imageBytes = Convert.FromBase64String(base64Data);
                TheCenterPhotoDTO img = new TheCenterPhotoDTO
                {
                    image = imageBytes,
                    floor =int.Parse(image.floor),
                    centerId=shoppingMall2.shoppingMallId
                };
                centerPhotoDTOs.Add(img);
            }
            //שליחת הנתונים לפונקציה שמוסיפה מרכז חדש
            await CreateNewCenter(shoppingMall2, centerPhotoDTOs, locationsList, intersectionsList, passCodes, edgesCrossing);

        }


        public async Task<bool> CreateNewCenter(CentersDTO shoppingMall, List<TheCenterPhotoDTO> TheCenterPhotoDTOList, List<LocationsDTO> locations, List<IntersectionsDTO> intersections, List<List<int>> passCodes,JToken edgesCrossing/*, List<dynamic> edgesCrossFloors*/)
        {
            //מעברים יוצרים בצד לקוח!!!

            try
            {
                List<LocationsDTO> locations2 = new List<LocationsDTO>();
                List<IntersectionsDTO> intersections2 = new List<IntersectionsDTO>();

                foreach (var mallPhoto in TheCenterPhotoDTOList)
                {
                    await _TheCenterPhotoService.AddAsync(mallPhoto);
                }
                //db הוספת כל נקודות המיקום ל
                foreach (var location in locations)
                {
                   // var n = await _LocationsService.AddAsync(location);
                   //קליטת הנקודות בחזרה
                    locations2.Add(await _LocationsService.AddAsync(location));
                }
                //bd הוספת כל נקודות ההצטלבות ל
                foreach (var intersection in intersections)
                {
                    //קליטת הנקודות בחזרה
                    intersections2.Add(await _IntersectionsService.AddAsync(intersection));
                }
                //  שליחת ליסט המיקומים, ההצטלבויות וליסט הליסטים לפונקציה שבונה את הקשתות לגרף 
                dynamic result = await BuildingEdges(locations2, intersections2, passCodes);
               
                //שליפת ליסט אובייקטי טבלת הקשר וליסט הקשתות של הגרף ממה שהוחזר מפונקציית בניית הקשתות
                List<TransitionsToIntersectionsDTO> TransitionsToIntersections = result.TransitionsToIntersections;
                List<EdgesDTO> Edges = result.Edges;
                LocationsDTO loc;
                LocationsDTO loc2;
                EdgesDTO e;
                //מעבר על רשימת קשתות חוצות קומה- המרחק בינהן יהיה אפס תמיד
                foreach (var edge in edgesCrossing)
                {
                    loc=locations2.FirstOrDefault(x => x.locationName==(string)edge["firstEdgeName"]);
                    loc2=locations2.FirstOrDefault(x => x.locationName==(string)edge["secondEdgeName"]);
                    e = new EdgesDTO
                    {
                        locationIdA = loc.coordinate.coordinateId,
                        locationIdB = loc2.coordinate.coordinateId,
                        distance = 0
                    };
                    Edges.Add(e);
                    e = new EdgesDTO
                    {
                        locationIdA = loc2.coordinate.coordinateId,
                        locationIdB = loc.coordinate.coordinateId,
                        distance = 0
                    };
                    Edges.Add(e);
                    
                }
                //db הוספת אובייקטי טבלת הקשר ל
                foreach (var item in TransitionsToIntersections)
                {
                    await _transitionsToIntersectionsService.AddAsync(item);
                }
                //db הוספת קשתות הגרף ל
                foreach (var edge in Edges)
                {
                    edge.centerId = shoppingMall.shoppingMallId;
                    await _edgesService.AddAsync(edge);
                }
                int idA;
                int idB;
               

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }


        }



        public double CalcDistance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
        }

        //באלגוריתם זה אני מוסיפה את הנקודות למסד הנתונים וכן את הקשתות
        //מקבל את המיקומים וההצטלבויות אחרי שכבר הכנסנו למסד נתונים
        public async Task<object> BuildingEdges(List<LocationsDTO> Locations, List<IntersectionsDTO> Intersections, List<List<int>> PassCodes)
        {
            try
            {
                //ליסט המוכן לקליטת קשתות
                List<EdgesDTO> edges = new List<EdgesDTO>();
                //ליסט המוכן לקליטת אובייקטי טבלת הקשר-מעברים להצטלבויות
                List<TransitionsToIntersectionsDTO> transitionsToIntersections = new List<TransitionsToIntersectionsDTO>();
                //מילון של "מעברים", המפתח במילון הוא מס' המעבר והערך הוא ליסט של מזהים (של נקודות מיקום או נקודות הצטלבות) שנמצאים במעבר זה
                var locationIdsByTransitionId = new Dictionary<int, List<int>>();

                //עובר על כל נקודות המיקום, ומוסיף את מזהה המיקום לליסט המתאים לו במילון המעברים
                foreach (var location in Locations)
                {
                    //בודק באיזה מעבר נמצא המיקום
                    int transitionId = location.transitions.trasitionId;
                    //אם לא קיים מפתח -מזהה מעבר, המתאים למזהה המעבר של המיקום, אז
                    if (!locationIdsByTransitionId.ContainsKey(transitionId))
                    {
                        //יוצר מפתח חדש- מזהה מעבר חדש
                        locationIdsByTransitionId[transitionId] = new List<int>();
                    }
                    //בכל אופן מכניס את מזהה המיקום לליסט שנמצא במפתח המתאים
                    locationIdsByTransitionId[transitionId].Add(location.coordinate.coordinateId);
                }


                //עובר על כל נקודות ההצטלבות, ומוסיף את מזהה הצטלבות לליסטים!!! (יכול להיות יותר מאחד) המתאימים לו במילון המעברים
                //נקודת הצטלבות יכולה להיות בכמה מעברים
                foreach (var intersection in Intersections)
                {
                    int index = Intersections.FindIndex(a => a.intersectionId == intersection.intersectionId);

                    foreach (var item in PassCodes[index])
                    {
                        if (!locationIdsByTransitionId.ContainsKey(item))
                        {
                            locationIdsByTransitionId[item] = new List<int>();
                        }
                        locationIdsByTransitionId[item].Add(intersection.coordinate.coordinateId);

                    }
                }
                double xA;
                double xB;
                double yA;
                double yB;

                //מעבר על המילון ויצירת קשתות , בין כל נקודה (הצטלבות/מיקום) לבין כל חברותיה למעבר 
                foreach (var transitionIdAndLocationIds in locationIdsByTransitionId)
                {
                    var locationIds = transitionIdAndLocationIds.Value;
                    for (int i = 0; i < locationIds.Count; i++)
                    {
                        for (int j = 0; j < locationIds.Count; j++)
                        {
                            if (i != j)
                            {

                                if (Locations.Any(x => x.coordinate.coordinateId == locationIds[i]))
                                {
                                    xA = Locations.Where(x => x.coordinate.coordinateId == locationIds[i]).Select(x => x.coordinate.x).First();
                                    yA = Locations.Where(x => x.coordinate.coordinateId == locationIds[i]).Select(x => x.coordinate.y).First();

                                }
                                else
                                {
                                    xA = Intersections.Where(x => x.coordinate.coordinateId == locationIds[i]).Select(x => x.coordinate.x).First();
                                    yA = Intersections.Where(x => x.coordinate.coordinateId == locationIds[i]).Select(x => x.coordinate.y).First();
                                }
                                if (Locations.Any(x => x.coordinate.coordinateId == locationIds[j]))
                                {
                                    xB = Locations.Where(x => x.coordinate.coordinateId == locationIds[j]).Select(x => x.coordinate.x).First();
                                    yB = Locations.Where(x => x.coordinate.coordinateId == locationIds[j]).Select(x => x.coordinate.y).First();

                                }
                                else
                                {
                                    xB = Intersections.Where(x => x.coordinate.coordinateId == locationIds[j]).Select(x => x.coordinate.x).First();
                                    yB = Intersections.Where(x => x.coordinate.coordinateId == locationIds[j]).Select(x => x.coordinate.y).First();
                                }
                                //יצירת אובייקט מסוג קשת בגרף
                                EdgesDTO edge = new EdgesDTO
                                {
                                    locationIdA = locationIds[i],
                                    locationIdB = locationIds[j],
                                    distance = CalcDistance(xA, yA, xB, yB)
                                };
                                //הוספת הקשת לליסט הקשתות
                                edges.Add(edge);
                            }

                        }
                    }
                    //יצירת אובייקטים לטבלת הקשר-מיקומים להצטלבויות
                    for (int i = 0; i < locationIds.Count; i++)
                    {
                        if (Intersections.Any(x => x.coordinate.coordinateId == locationIds[i]))
                        {
                            TransitionsToIntersectionsDTO transitionsToIntersection = new TransitionsToIntersectionsDTO
                            {
                                intersectionId = locationIds[i],
                                transitionId = transitionIdAndLocationIds.Key

                            };
                            transitionsToIntersections.Add(transitionsToIntersection);

                        }
                    }
                }

                //שליחת 2 משתנים:
                //רשימת אובייקטי טבלת הקשר מיקומים להצטלבויות-
                //רשימת אובייקטי הקשתות של הגרף-
                var result = new
                {
                    TransitionsToIntersections = transitionsToIntersections,
                    Edges = edges
                };

                return result;
            }
            catch (Exception e)
            {
                return null;

            }
            
        }




    }



}
