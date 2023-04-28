﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRouting.Repositories.Entities
{
    public class Transition
    {
        [Key]
        public int trasitionId { get; set; }
        public string transitionsName { get; set; }
    }
}
