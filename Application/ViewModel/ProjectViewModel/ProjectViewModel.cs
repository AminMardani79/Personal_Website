using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.ProjectViewModel
{
    public class ProjectViewModel
    {
        public int ProjectId { get; set; }
        public string ProjectTitle { get; set; }
        public string ProjectSubTitle { get; set; }
        public string ProjectDescription { get; set; }
        public string ProjectImage { get; set; }
        public string DownloadLink { get; set; }
        public List<ProjectCategoryViewModel.ProjectCategoryViewModel> Categories { get; set; }
    }
}
