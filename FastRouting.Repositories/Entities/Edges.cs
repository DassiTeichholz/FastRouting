using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRouting.Repositories.Entities
{
    public class Edges
    {
        public int LocationIdA { get; set; }
        public int LocationIdB { get; set; }

        public double Distance { get; set; }


    }
}
