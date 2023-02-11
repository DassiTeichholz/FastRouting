using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRouting.Common.DTO
{
    public class IntersectionsDTO
    {
        public int IntersectionID { get; set; }//קוד הצלבות
        public CoordinateDTO Coordinate { get; set; }
        public ShoppingMallsDTO shoppingMalls { get; set; }
    }
}
