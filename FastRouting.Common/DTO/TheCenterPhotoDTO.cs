using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRouting.Common.DTO
{
    public class TheCenterPhotoDTO
    {
        public int theMallPhotoId { get; set; }
        public byte[] image { get; set; }
        public int floor { get; set; }
        public int centerId { get; set; }

    }
}
