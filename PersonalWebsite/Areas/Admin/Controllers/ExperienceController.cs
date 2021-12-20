using Application.Interface;
using Application.ViewModel.ExperienceViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = "Authorize")]
    public class ExperienceController : Controller
    {
        private readonly IExperienceService _experienceService;

        public ExperienceController(IExperienceService experienceService)
        {
            _experienceService = experienceService;
        }
        [HttpGet]
        [Route("/Admin/Experiences/{search?}")]
        public IActionResult Index(string search, int pageNumber = 1)
        {
            int take = 6;
            var experiences = _experienceService.GetExperiencesList(search ?? "", take, pageNumber);
            return View(experiences);
        }
        [HttpGet]
        [Route("/Admin/CreateExperience")]
        public IActionResult CreateExperience()
        {
            return View();
        }

        [HttpPost]
        [Route("/Admin/CreateExperience")]
        public IActionResult CreateExperience(CreateExperienceViewModel model)
        {
            if (ModelState.IsValid)
            {
                _experienceService.CreateExperience(model);
                return Redirect($"/Admin/Experiences");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        [Route("/Admin/EditExperience/{id}")]
        public IActionResult EditExperience(int id)
        {
            var model = _experienceService.GetExperienceById(id).Result;
            return View(model);
        }

        [HttpPost]
        [Route("/Admin/EditExperience/{id}")]
        public IActionResult EditExperience(EditExperienceViewModel model)
        {
            if (ModelState.IsValid)
            {
                _experienceService.EditExperience(model);
                return Redirect($"/Admin/Experiences");
            }
            else
            {
                return View(model);
            }
        }
        [HttpGet]
        [Route("/Admin/DeleteExperience/{id}")]
        public void DeleteExperience(int id)
        {
            _experienceService.DeleteExperience(id);
        }
    }
}