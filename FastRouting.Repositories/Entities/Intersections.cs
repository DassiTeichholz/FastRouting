using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRouting.Repositories.Entities
{
    public class Intersections
    {
        public int IntersectionID { get; set; }//קוד הצלבות
        public Coordinate Coordinate { get; set; }
        //public int AccessPointID  { get; set; }//קוד נקודת גישה

        public shoppingMalls shoppingMalls { get; set; }

    }
}
