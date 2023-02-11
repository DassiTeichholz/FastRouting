using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRouting.Common.DTO
{
    public class CoordinateDTO
    {
        public int Id { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public int Z { get; set; }//floor
    }
}
