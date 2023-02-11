using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRouting.Repositories.Entities
{
    public class shoppingMalls
    {
        public int Id { get; set; }
        public int Name { get; set; }

        public TheMallPhotos TheMallPhotos { get; set; }

    }
}
