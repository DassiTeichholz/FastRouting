using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRouting.Repositories.Entities
{
    public class TransitionsToIntersections
    {
        [Key]
        public int TransitionId { get; set; }//מזהה מעבר
        [Key]
        public int IntersectionID { get; set; }//מזהה הצטלבות



    }
}
