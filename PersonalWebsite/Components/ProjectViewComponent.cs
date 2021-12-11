using Application.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace PersonalWebsite.Components
{
    public class ProjectViewComponent:ViewComponent
    {
        private readonly IProjectService _projectService;

        public ProjectViewComponent(IProjectService projectService)
        {
            _projectService = projectService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("/Views/Shared/_Project.cshtml",await _projectService.ShowProjects());
        }
    }
}
