using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace FastRouting.Repositories.Entities
{
    public class shoppingMalls
    {
        [Key]
        public int shoppingMallId { get; set; }
        public string name { get; set; }
       //public virtual ICollection<TheMallPhotos> TheMallPhotos { get; set; }

        //public TheMallPhotos TheMallPhotos { get; set; }

    }
}
