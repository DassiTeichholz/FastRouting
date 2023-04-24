using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRouting.Common.DTO
{
    public class TheMallPhotosDTO
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public int floor { get; set; }
        public int centerId { get; set; }

    }
}
