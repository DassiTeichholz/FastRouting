using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace FastRouting.Repositories.Entities
{
    public class Location
    {
        [Key]
        public int id { get; set; }
        public Coordinate coordinate { get; set; }
        //public int AccessPointID { get; set; }//מזהה נקודת גישה 
        public string locationName { get; set; }//שם המיקום
        [ForeignKey("Transition")]
        
        public int transitionId { get; set; }

      
        public Transition transitions { get; set; }//מזהה מעבר

        [ForeignKey("LocationTypes")]

        public int locationTypesId { get; set; }
        public LocationTypes locationTypes { get; set; }//מזהה סוג מיקום
                                                        //public shoppingMalls shoppingMalls { get; set; }
        public int centerId { get; set; }
        
        
        
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
    }
}
