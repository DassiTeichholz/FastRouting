using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRouting.Repositories.Entities
{
    [PrimaryKey("LocationIdA", "LocationIdB")]
    public class Edges
    {
        
        public int LocationIdA { get; set; }
       
        public int LocationIdB { get; set; }

        public double Distance { get; set; }
        public int centerId { get; set; }


    }
}
