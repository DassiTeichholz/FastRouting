using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using static System.Net.Mime.MediaTypeNames;
using System.ComponentModel.DataAnnotations;

namespace FastRouting.Repositories.Entities
{
    public  class TheMallPhotos
    {
        [Key]
        public int Id { get; set; }
        public int centerId { get; set; }
        public byte[] Image { get; set; }
        public int floor { get; set; }

    }
}
