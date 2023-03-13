using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRouting.Repositories.Entities
{
    [PrimaryKey("TransitionId", "IntersectionID")]
    public class TransitionsToIntersections
    {
        
        public int TransitionId { get; set; }//מזהה מעבר
       
        public int IntersectionID { get; set; }//מזהה הצטלבות



    }
}
