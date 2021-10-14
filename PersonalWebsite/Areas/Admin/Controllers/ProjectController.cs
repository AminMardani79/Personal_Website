using Application.Interface;
using Application.ViewModel.ProjectViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }
        [HttpGet]
        [Route("/Admin/Projects/{search?}")]
        public IActionResult Index(string search, int pageNumber = 1)
        {
            int take = 6;
            var projects = _projectService.GetProjectsList(search ?? "", take, pageNumber);
            return View(projects);
        }
        [HttpGet]
        [Route("/Admin/CreateProject")]
        public IActionResult CreateProject()
        {
            return View();
        }

        [HttpPost]
        [Route("/Admin/CreateProject")]
        public IActionResult CreateProject(CreateProjectViewModel model)
        {
            if (ModelState.IsValid)
            {
                _projectService.CreateProject(model);
                return Redirect($"/Admin/Projects");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        [Route("/Admin/EditProject/{id}")]
        public IActionResult EditProject(int id)
        {
            var model = _projectService.GetProjectById(id).Result;
            return View(model);
        }

        [HttpPost]
        [Route("/Admin/EditProject/{id}")]
        public IActionResult EditProject(EditProjectViewModel model)
        {
            if (ModelState.IsValid)
            {
                _projectService.EditProject(model);
                return Redirect($"/Admin/Projects");
            }
            else
            {
                return View(model);
            }
        }
        [HttpGet]
        [Route("/Admin/DeleteProject/{id}")]
        public void DeleteProject(int id)
        {
            _projectService.DeleteProject(id);
        }
    }
}