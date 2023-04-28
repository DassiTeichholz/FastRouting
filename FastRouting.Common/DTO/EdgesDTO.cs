using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRouting.Common.DTO
{
    public class EdgesDTO
    {
        public int locationIdA { get; set; }
        public int locationIdB { get; set; }

        public double distance { get; set; }
        public int centerId { get; set; }
    }
}
