using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRouting.Common.DTO
{
    public class LocationsDTO
    {
        public int Id { get; set; }
        public CoordinateDTO Coordinate { get; set; }
        //public int AccessPointID { get; set; }//מזהה נקודת גישה 
        public string LocationName { get; set; }//שם המיקום

        public TransitionsDTO Transitions { get; set; }//מזהה מעבר

        public LocationTypesDTO LocationTypes { get; set; }//מזהה סוג מיקום
        public ShoppingMallsDTO shoppingMalls { get; set; }
    }
}
