using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRouting.Repositories.Entities
{
    public class Edges
    {
        [Key]
        public int LocationIdA { get; set; }
        [Key]
        public int LocationIdB { get; set; }

        public double Distance { get; set; }


    }
}
