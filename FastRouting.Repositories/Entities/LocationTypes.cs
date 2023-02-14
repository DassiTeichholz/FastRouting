using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRouting.Repositories.Entities
{
    public class LocationTypes
    {
        [Key]
        public int locationTypeId { get; set; }//מזהה סוג מיקום

        public string locationType { get; set; }//סוג מיקום
    }
}
