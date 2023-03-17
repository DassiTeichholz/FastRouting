using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FastRouting.Repositories.Entities
{
    public class Location
    {
        [Key]
        public int Id { get; set; }
        public Coordinate Coordinate { get; set; }
        //public int AccessPointID { get; set; }//מזהה נקודת גישה 
        public string LocationName { get; set; }//שם המיקום
        
        public int TransitionId { get; set; }

        //private Subject? subject;

        //public Subject Subject
        //{
        //    get { return subject; }
        //    set
        //    {
        //        subject = null!;
        //        subject = value;
        //    }
        //}
        public Transition? Transitions { get; set; }//מזהה מעבר
        
        public int LocationTypesId { get; set; }
        public LocationTypes? LocationTypes { get; set; }//מזהה סוג מיקום
                                                        //public shoppingMalls shoppingMalls { get; set; }
        public int centerId { get; set; }
    }
}
