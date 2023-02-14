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
        public int Id { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public int Z { get; set; }//floor
    }
}
