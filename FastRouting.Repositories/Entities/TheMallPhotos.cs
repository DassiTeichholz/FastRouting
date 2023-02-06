using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using static System.Net.Mime.MediaTypeNames;

namespace FastRouting.Repositories.Entities
{
    public  class TheMallPhotos
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }

    }
}
