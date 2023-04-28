using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRouting.Repositories.Entities
{
    public class Intersections
    {
        [Key]
        public int intersectionId { get; set; }//קוד הצלבות
        public Coordinate coordinate { get; set; }
       
        public int centerId { get; set; }
    }
}
