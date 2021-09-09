using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class AboutMe
    {
        public int AboutMeId { get; set; }
        public string AboutMeDes { get; set; }
        public string AboutMeContext { get; set; }
        public int CustomerCount { get; set; }
        public int ProjectsCount { get; set; }

    }
}