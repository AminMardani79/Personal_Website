﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Major
    {
        public int MajorId { get; set; }
        public string MajorTitle { get; set; }
        public string MajorSubTitle { get; set; } 
        public string MajorStart { get; set; }
        public string MajorEnd { get; set; }
    }
}
