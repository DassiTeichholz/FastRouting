﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRouting.Common.DTO
{
    public class LocationsDTO
    {
        public int Id { get; set; }
        public int Coordinate { get; set; }
        //public int AccessPointID { get; set; }//מזהה נקודת גישה 
        public string LocationName { get; set; }//שם המיקום

        public int Transitions { get; set; }//מזהה מעבר

        public int LocationTypes { get; set; }//מזהה סוג מיקום
        public int shoppingMalls { get; set; }
    }
}
