using FastRouting.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRouting.Services.Services
{
    public static class Algorithm
    {
        //באלגוריתם זה אני מוסיפה את הנקודות למסד הנתונים וכן את הקשתות
        public static bool AddMall(List<LocationsDTO> Locations, List<IntersectionsDTO> Intersections,List<int> PassCodes)
        {
            try
            {
                bool[] LocationsIsVisit = new bool[Locations.Count];
                bool[] IntersectionsIsVisit = new bool[Intersections.Count];
                



                return true;
            }
            catch(Exception e)
            {
                return false;

            }
        }
    }
}
