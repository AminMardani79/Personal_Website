using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Experience
    {
        public int ExperienceId { get; set; }
        public string ExperienceTitle { get; set; }
        public string ExperienceSubTitle { get; set; }
        public string Description { get; set; }
        public string GroupName { get; set; }
        public string Date { get; set; }
        public string ExperienceType { get; set; }
        public string Image { get; set; }
    }
}