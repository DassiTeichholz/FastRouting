using AutoMapper;
using FastRouting.Common.DTO;
using FastRouting.Repositories.Interfaces;
using FastRouting.Services.Interfaces;
using FastRouting.Services.Interfaces.ILogic;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRouting.Services.Services.Logic
{
    public class AddingACenter : IAddingACenter
    {

        private readonly IshoppingMallsService _shoppingMallService;
        private readonly ILocationsService _LocationsService;
        private readonly IIntersectionsService _IntersectionsService;
        private readonly ITheMallPhotosService _theMallPhotosService;
        private readonly IMapper _mapper;
        private readonly IEdgesService _edgesService;
        private readonly ITransitionsService _transitionsService;
        private readonly ILocationTypesService _locationTypesService;
        private readonly ITransitionsToIntersectionsService _transitionsToIntersectionsService;
        public AddingACenter(IMapper mapper, IshoppingMallsService shoppingMallService, IEdgesService edgesService, ITheMallPhotosService theMallPhotosService, IIntersectionsService intersectionsService, ILocationsService locationsService, ITransitionsService transitionsService, ILocationTypesService locationTypesService, ITransitionsToIntersectionsService transitionsToIntersectionsService)
        {
            _mapper = mapper;
            _shoppingMallService = shoppingMallService;
            _edgesService = edgesService;
            _theMallPhotosService = theMallPhotosService;
            _IntersectionsService = intersectionsService;
            _LocationsService = locationsService;
            _transitionsService = transitionsService;
            _locationTypesService = locationTypesService;
            _transitionsToIntersectionsService = transitionsToIntersectionsService;
        }

        public async Task DataPreparationFunc(string centerName)
        {
            //הליסטים שיוחזרו בסוף, אחרי שננתח את הקובץ
            List<LocationsDTO> locationsList = new List<LocationsDTO>();
            List<IntersectionsDTO> intersectionsList = new List<IntersectionsDTO>();
            List<List<int>> passCodes = new List<List<int>>();




            string jsonString = File.ReadAllText("data.json");
            JObject jsonObject = JObject.Parse(jsonString);
            var locationsInTrasitions = jsonObject["locationInTrasition"];
            var edgesCrossing = jsonObject["edgesCrossing"];
            var intersections = jsonObject["intersection"];
            int num = 0;
            ShoppingMallsDTO shoppingMall = new ShoppingMallsDTO
            {

                shoppingMallId = 0,
                Name = centerName
            };
            ShoppingMallsDTO shoppingMall2 = await _shoppingMallService.AddAsync(shoppingMall);

            //עובר על כל מעבר ומוסיף 
            foreach (var item in locationsInTrasitions)
            {
                TransitionsDTO trasition = new TransitionsDTO
                {

                    trasitionId = 0,
                    transitionsName = "trasition number " + num

                };
                TransitionsDTO transition = await _transitionsService.AddAsync(trasition);
                jsonObject["locationInTrasition"][num]["transitionId"] = transition.trasitionId;
                num++;
                var locations = item["locations"];
                foreach (var loc in locations)
                {
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
                    locationsList.Add(locationDTO);
                }
            }
            // Convert the JObject to a JSON string
            jsonString = jsonObject.ToString();

            // Write the updated JSON string back to the file
            File.WriteAllText("data.json", jsonString);


            jsonString = File.ReadAllText("data.json");
            jsonObject = JObject.Parse(jsonString);
            locationsInTrasitions = jsonObject["locationInTrasition"];

            List<int> tmp = new List<int>();
            int x;
            int y;

            foreach (var intersec in intersections)
            {
                IntersectionsDTO intersection = new IntersectionsDTO
                {
                    intersectionId = 0,
                    coordinate = new CoordinateDTO
                    {
                        x = (double)intersec["coordinate"]["x"],
                        y = (double)intersec["coordinate"]["y"],
                        z = (int)intersec["coordinate"]["z"]
                    },
                    centerId = shoppingMall2.shoppingMallId
                };
                intersectionsList.Add(intersection);
                var transitionsNums = intersec["transitionsNums"];
                foreach (var index in transitionsNums)
                {
                    y = (int)index;
                    x = (int)locationsInTrasitions[y]["transitionId"];
                    tmp.Add(x);
                }
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

            await CreateNewMall(shoppingMall2, locationsList, intersectionsList, passCodes);

        }


        public async Task<bool> CreateNewMall(ShoppingMallsDTO shoppingMall/*, List<TheMallPhotosDTO> theMallPhotosDTOList*/, List<LocationsDTO> locations, List<IntersectionsDTO> intersections, List<List<int>> passCodes/*, List<dynamic> edgesCrossFloors*/)
        {
            //מעברים יוצרים בצד לקוח!!!

            try
            {
                List<LocationsDTO> locations2 = new List<LocationsDTO>();
                List<IntersectionsDTO> intersections2 = new List<IntersectionsDTO>();

                //foreach (var mallPhoto in theMallPhotosDTOList)
                //{
                //    await _theMallPhotosService.AddAsync(mallPhoto);
                //}
                foreach (var location in locations)
                {
                   // var n = await _LocationsService.AddAsync(location);
                    locations2.Add(await _LocationsService.AddAsync(location));
                }
                foreach (var intersection in intersections)
                {
                    intersections2.Add(await _IntersectionsService.AddAsync(intersection));
                }
                dynamic result = Algorithm.BuildingEdges(locations2, intersections2, passCodes);


                List<TransitionsToIntersectionsDTO> TransitionsToIntersections = result.TransitionsToIntersections;
                List<EdgesDTO> Edges = result.Edges;

                foreach (var item in TransitionsToIntersections)
                {
                    await _transitionsToIntersectionsService.AddAsync(item);
                }
                foreach (var edge in Edges)
                {
                    edge.centerId = shoppingMall.shoppingMallId;
                    await _edgesService.AddAsync(edge);
                }
                int idA;
                int idB;
                //foreach (var obj in edgesCrossFloors)
                //{
                //    var location = await _LocationsService.GetByNameAsync(obj[0]);
                //    idA = location.Coordinate.Id;

                //    location = await _LocationsService.GetByNameAsync(obj[1]);
                //    idB = location.Coordinate.Id;
                //    EdgesDTO edge = new EdgesDTO
                //    {
                //        LocationIdA=idA,
                //        LocationIdB=idB,
                //        Distance=0

                //    };
                //    await _edgesService.AddAsync(edge);
                //}


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
                List<EdgesDTO> edges = new List<EdgesDTO>();
                // List<IntersectionsDTO> intersections = new List<IntersectionsDTO>();
                List<TransitionsToIntersectionsDTO> transitionsToIntersections = new List<TransitionsToIntersectionsDTO>();
                // List<LocationsDTO> locations = new List<LocationsDTO>();
                //מילון של "מעברים", המפתח במילון הוא מס' המעבר והערך הוא ליסט של מזהים שנמצאים במעבר זה
                var locationIdsByTransitionId = new Dictionary<int, List<int>>();

                //עובר על כל נקודות המיקום, ומוסיף את מזהה המיקום לליסט המתאים לו במילון המעברים
                foreach (var location in Locations)
                {
                    int transitionId = location.transitions.trasitionId;
                    if (!locationIdsByTransitionId.ContainsKey(transitionId))
                    {
                        locationIdsByTransitionId[transitionId] = new List<int>();
                    }
                    locationIdsByTransitionId[transitionId].Add(location.coordinate.coordinateId);
                }

                //עובר על כל נקודות ההצטלבות, ומוסיף את מזהה הצטלבות לליסטים!!! (יכול להיות יותר מאחד) המתאימים לו במילון המעברים

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
                                EdgesDTO edge = new EdgesDTO
                                {
                                    locationIdA = locationIds[i],
                                    locationIdB = locationIds[j],
                                    distance = CalcDistance(xA, yA, xB, yB)
                                };
                                edges.Add(edge);
                            }

                        }
                    }
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


                var result = new
                {
                    TransitionsToIntersections = transitionsToIntersections,
                    Edges = edges
                };

                return result;




                //return edges;
            }
            catch (Exception e)
            {
                return null;

            }
        }




    }



}
