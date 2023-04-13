using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRouting.Common.DTO
{
    public class LocationsDTO
    {
        public int id { get; set; }
        public CoordinateDTO coordinate { get; set; }
        //public int AccessPointID { get; set; }//מזהה נקודת גישה 
        public string locationName { get; set; }//שם המיקום
        public int transitionId { get; set; }

        public TransitionsDTO? transitions { get; set; }//מזהה מעבר
        public int locationTypesId { get; set; }
        public LocationTypesDTO? locationTypes { get; set; }//מזהה סוג מיקום
                                                           //public ShoppingMallsDTO shoppingMalls { get; set; }
        public int centerId { get; set; }
    }
}
