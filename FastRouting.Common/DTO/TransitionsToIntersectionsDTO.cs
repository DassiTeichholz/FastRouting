using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRouting.Common.DTO
{
    public class TransitionsToIntersectionsDTO
    {
        public int TransitionId { get; set; }//מזהה מעבר

        public int IntersectionID { get; set; }//מזהה הצטלבות
    }
}
