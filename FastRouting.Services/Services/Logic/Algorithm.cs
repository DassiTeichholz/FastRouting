using FastRouting.Common.DTO;
using FastRouting.Repositories.Entities;
using FastRouting.Repositories.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRouting.Services.Services.Logic
{
 
    public static class Algorithm
    {


        //פונקציה לחישוב מרחק בין שתי קאורדיננטות
        public static double CalcDistance(double x1, double y1, double x2, double y2)
        {
         return Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
        }

       // תפקידה של פונקציה זו, ליצור קשתות לפי נקודות המיקום, ההצטלבות, וליסט של ליסטים של מזהי מעברים
       // הנחת האלגוריתם- כל הנקודות הנמצאות באותו מעבר, צריך ליצור בינהן קשתות ישירות, כל נקודה, ליצור בינה קשת לבין כל אחת מחברותיה למעבר
      public static object BuildingEdges(List<LocationsDTO> Locations, List<IntersectionsDTO> Intersections, List<List<int>> PassCodes)
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
                //אם לא קיים מפתח -מזהה מעבר, המתאים למזהה המעבר של המיקום
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







