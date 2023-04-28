using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRouting.Repositories.Entities
{
    public class Coordinate
    {
        [Key]
        public int coordinateId { get; set; }
        public double x { get; set; }
        public double y { get; set; }
        public int z { get; set; }//floor
    }
}
