using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string ProjectTitle { get; set; }
        public string ProjectSubTitle { get; set; }
        public string ProjectDescription { get; set; }
        public string ProjectImage { get; set; }
        public string DownloadLink { get; set; }

    }
}