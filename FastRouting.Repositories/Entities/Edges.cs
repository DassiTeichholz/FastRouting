using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRouting.Repositories.Entities
{
    [PrimaryKey("locationIdA", "locationIdB")]
    public class Edges
    {
        
        public int locationIdA { get; set; }
       
        public int locationIdB { get; set; }

        public double distance { get; set; }
        public int centerId { get; set; }


    }
}
