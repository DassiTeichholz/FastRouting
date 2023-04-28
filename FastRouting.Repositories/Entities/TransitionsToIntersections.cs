using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRouting.Repositories.Entities
{
    [PrimaryKey("transitionId", "intersectionId")]
    public class TransitionsToIntersections
    {
        
        public int transitionId { get; set; }//מזהה מעבר
       
        public int intersectionId { get; set; }//מזהה הצטלבות



    }
}
