using FastRouting.Common.DTO;
using FastRouting.Repositories.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRouting.Services.Services
{
    public static class Algorithm
    {
        //באלגוריתם זה אני מוסיפה את הנקודות למסד הנתונים וכן את הקשתות
        public static bool AddMall(List<LocationsDTO> Locations, List<IntersectionsDTO> Intersections, List<int>[] PassCodes)
        {
            try
            {
                var locationIdsByTransitionId = new Dictionary<int, List<int>>();

                foreach (var location in Locations)
                {
                    int transitionId = location.Transitions;
                    if (!locationIdsByTransitionId.ContainsKey(transitionId))
                    {
                        locationIdsByTransitionId[transitionId] = new List<int>();
                    }
                    locationIdsByTransitionId[transitionId].Add(location.Coordinate);
                }

                foreach (var intersection in Intersections)
                {
                    int index = Intersections.FindIndex(a => a.IntersectionID==intersection.IntersectionID);

                    foreach (var item in PassCodes[index])
                    {
                        if (!locationIdsByTransitionId.ContainsKey(item))
                        {
                            locationIdsByTransitionId[item] = new List<int>();
                        }
                        locationIdsByTransitionId[item].Add(intersection.Coordinate);

                    }
                }
                //////////TransitionsToIntersectionsServer TransitionsToIntersectionsServer = new TransitionsToIntersectionsServer();
                int TransitionId;
                int IntersectionID;
                foreach (var transitionIdAndLocationIds in locationIdsByTransitionId)
                {
                    var locationIds = transitionIdAndLocationIds.Value;
                    for (int i = 0; i < locationIds.Count; i++)
                    {
                        for (int j = 0; j < locationIds.Count; j++)
                        {
                            if (i!=j)
                            {
                                EdgesDTO edge = new EdgesDTO
                                {
                                    LocationIdA = locationIds[i],
                                    LocationIdB = locationIds[j],
                                    Distance = 0
                                };


                                //AddAsync(edge);
                            }

                        }
                    }
                    for (int i = 0; i < locationIds.Count; i++)
                    {
                        TransitionsToIntersectionsDTO TransitionsToIntersections = new TransitionsToIntersectionsDTO
                        {

                        }
                        
                            
                    }
                    ////////TransitionsToIntersectionsServer.AddAsync(TransitionsToIntersections);
                }
            
                   //////////LocationsService LocationsService = new LocationsService();
                   //////////foreach (var location in Locations)
                   //////////{
                   //////////    LocationsService.AddAsync(location);

                   //////////}
                     //////////IntersectionsService IntersectionsService = new IntersectionsService();
                     //////////foreach (var intersection in Intersections)
                   //////////{
                      //////////    IntersectionsService.AddAsync(intersection);
                   //////////}





               return true;
            }
            catch (Exception e)
            {
                return false;

            }
        }
        

}
    }






     
}
