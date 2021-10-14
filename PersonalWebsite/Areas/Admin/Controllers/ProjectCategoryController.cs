using Application.Interface;
using Application.ViewModel.ProjectCategoryViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProjectCategoryController : Controller
    {
        private readonly IProjectCategoryService _projectCategoryService;
        public ProjectCategoryController(IProjectCategoryService projectCategoryService)
        {
            _projectCategoryService = projectCategoryService;
        }
        [HttpGet]
        [Route("/Admin/Categories/{search?}")]
        public IActionResult Categories(string search)
        {
            var categories = _projectCategoryService.GetProjectCategoryList(search ?? "");
            return View(categories);
        }
        [HttpGet]
        [Route("/Admin/DeletedCategories/{search?}")]
        public IActionResult DeletedCategories(string search)
        {
            var categories = _projectCategoryService.GetDeletedProjectCategoryList(search ?? "");
            return View(categories);
        }
        [HttpGet]
        [Route("/Admin/CreateCategory")]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        [Route("/Admin/CreateCategory/{id}")]
        public IActionResult CreateCategory(CreateProjectCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                _projectCategoryService.CreateProjectCategory(model);
                return Redirect($"/Admin/Categories");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        [Route("/Admin/EditCategory/{id}")]
        public IActionResult EditCategory(int id)
        {
            var model = _projectCategoryService.GetProjectCategoryById(id).Result;
            return View(model);
        }

        [HttpPost]
        [Route("/Admin/EditCategory/{id}")]
        public IActionResult EditCategory(EditProjectCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                _projectCategoryService.EditProjectCategory(model);
                return Redirect($"/Admin/Categories");
            }
            else
            {
                return View(model);
            }
        }
        [HttpGet]
        [Route("/Admin/DeleteCategory/{id}")]
        public void DeleteCategory(int id)
        {
            _projectCategoryService.DeleteProjectCategory(id);
        }
        [HttpGet]
        [Route("/Admin/AddCategoryToTrashList/{id}")]
        public void AddCategoryToTrashList(int id)
        {
            _projectCategoryService.AddCategoryToTrashList(id);
        }
        [HttpGet]
        [Route("/Admin/BackToCategoryList/{id}")]
        public void BackToCategoryList(int id)
        {
            _projectCategoryService.BackToList(id);
        }
    }
}
