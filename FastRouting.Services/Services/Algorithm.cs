using FastRouting.Common.DTO;
using FastRouting.Repositories.Entities;
using FastRouting.Repositories.Interfaces;
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

    
      static double CalcDistance(double x1, double y1, double x2, double y2)
      {
         return Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
      }

    //באלגוריתם זה אני מוסיפה את הנקודות למסד הנתונים וכן את הקשתות
    public static List<EdgesDTO> BuildingEdges(List<LocationsDTO> Locations, List<IntersectionsDTO> Intersections, List<int>[] PassCodes)
        {
            try
            {
                List<EdgesDTO> edges = new List<EdgesDTO>();
                List<IntersectionsDTO> intersections = new List<IntersectionsDTO>();
                List<TransitionsToIntersectionsDTO> transitionsToIntersections = new List<TransitionsToIntersectionsDTO>();
                List<LocationsDTO> locations = new List<LocationsDTO>();
                var locationIdsByTransitionId = new Dictionary<int, List<int>>();

                foreach (var location in Locations)
                {
                    int transitionId = location.Transitions.Id;
                    if (!locationIdsByTransitionId.ContainsKey(transitionId))
                    {
                        locationIdsByTransitionId[transitionId] = new List<int>();
                    }
                    locationIdsByTransitionId[transitionId].Add(location.Coordinate.Id);
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
                        locationIdsByTransitionId[item].Add(intersection.Coordinate.Id);

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
                            if (i!=j)
                            {
                                
                                if (Locations.Any(x => x.Coordinate.Id == locationIds[i]))
                                {
                                    xA=(Locations.Where(x => x.Coordinate.Id == locationIds[i]).Select(x=>x.Coordinate.X).First());
                                    yA=(Locations.Where(x => x.Coordinate.Id == locationIds[i]).Select(x=>x.Coordinate.Y).First());

                                }
                                else
                                {
                                    xA=(Intersections.Where(x => x.Coordinate.Id == locationIds[i]).Select(x => x.Coordinate.X).First());
                                    yA=(Intersections.Where(x => x.Coordinate.Id == locationIds[i]).Select(x => x.Coordinate.Y).First());
                                }
                                if (Locations.Any(x => x.Coordinate.Id == locationIds[j]))
                                {
                                    xB=(Locations.Where(x => x.Coordinate.Id == locationIds[j]).Select(x => x.Coordinate.X).First());
                                    yB=(Locations.Where(x => x.Coordinate.Id == locationIds[j]).Select(x => x.Coordinate.Y).First());

                                }
                                else
                                {
                                    xB=(Intersections.Where(x => x.Coordinate.Id == locationIds[j]).Select(x => x.Coordinate.X).First());
                                    yB=(Intersections.Where(x => x.Coordinate.Id == locationIds[j]).Select(x => x.Coordinate.Y).First());
                                }
                                EdgesDTO edge = new EdgesDTO
                                {
                                    LocationIdA = locationIds[i],
                                    LocationIdB = locationIds[j],
                                    Distance = CalcDistance(xA,yA,xB,yB)
                                };
                                edges.Add(edge);
                            }

                        }
                    }
                    for (int i = 0; i < locationIds.Count; i++)
                    {
                        if (intersections.Any(x => x.Coordinate.Id == locationIds[i]))
                        {
                            TransitionsToIntersectionsDTO transitionsToIntersection = new TransitionsToIntersectionsDTO
                            {
                                IntersectionID = locationIds[i],
                                TransitionId = transitionIdAndLocationIds.Key

                            };
                            transitionsToIntersections.Add(transitionsToIntersection);

                        }
                    }
                }

                




                return edges;
            }
            catch (Exception e)
            {
                return null;

            }
        }
        

    }
}







