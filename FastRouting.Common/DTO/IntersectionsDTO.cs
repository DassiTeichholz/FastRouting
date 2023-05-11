using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRouting.Common.DTO
{
    public class IntersectionsDTO
    {
        public int intersectionId { get; set; }//קוד הצלבות
        public CoordinateDTO coordinate { get; set; }
        // public CentersDTO Centers { get; set; }
        public int centerId { get; set; }
        public bool IntersectionOnLocation { get; set; }
    }
}
