using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace FastRouting.Repositories.Entities
{
    public class Centers
    {
        [Key]
        public int shoppingMallId { get; set; }
        public string name { get; set; }
       //public virtual ICollection<TheCenterPhoto> TheCenterPhoto { get; set; }

        //public TheCenterPhoto TheCenterPhoto { get; set; }

    }
}
