using Application.Interface;
using Application.ViewModel.MajorViewModel;
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
    public class MajorController : Controller
    {
        private readonly IMajorService _majorService;

        public MajorController(IMajorService majorService)
        {
            _majorService = majorService;
        }
        [HttpGet]
        [Route("/Admin/Majors/{search?}")]
        public IActionResult Index(string search, int pageNumber = 1)
        {
            int take = 6;
            var majors = _majorService.GetMajorsList(search ?? "", take, pageNumber);
            return View(majors);
        }
        [HttpGet]
        [Route("/Admin/CreateMajor")]
        public IActionResult CreateMajor()
        {
            return View();
        }

        [HttpPost]
        [Route("/Admin/CreateMajor")]
        public IActionResult CreateMajor(CreateMajorViewModel model)
        {
            if (ModelState.IsValid)
            {
                _majorService.CreateMajor(model);
                return Redirect($"/Admin/Majors");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        [Route("/Admin/EditMajor/{id}")]
        public IActionResult EditMajor(int id)
        {
            var model = _majorService.GetMajorById(id).Result;
            return View(model);
        }

        [HttpPost]
        [Route("/Admin/EditMajor/{id}")]
        public IActionResult EditMajor(EditMajorViewModel model)
        {
            if (ModelState.IsValid)
            {
                _majorService.EditMajor(model);
                return Redirect($"/Admin/Majors");
            }
            else
            {
                return View(model);
            }
        }
        [HttpGet]
        [Route("/Admin/DeleteMajor/{id}")]
        public void DeleteMajor(int id)
        {
            _majorService.DeleteMajor(id);
        }
    }
}