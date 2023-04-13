using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRouting.Common.DTO
{
    public class CoordinateDTO
    {
        public int id { get; set; }
        public double x { get; set; }
        public double y { get; set; }
        public int z { get; set; }//floor
    }
}
