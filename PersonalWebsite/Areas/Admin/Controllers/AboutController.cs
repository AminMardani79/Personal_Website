using Application.Interface;
using Application.ViewModel.AboutMeViewModel;
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
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }
        [HttpGet]
        [Route("/Admin/EditAbout")]
        public IActionResult Edit()
        {
            var model = _aboutService.GetAbout().Result;
            return View(model);
        }

        [HttpPost]
        [Route("/Admin/EditAbout")]
        public IActionResult Edit(EditAboutMeViewModel model)
        {
            if (ModelState.IsValid)
            {
                _aboutService.UpdateAbout(model);
                return RedirectToAction("Edit");
            }
            else
            {
                return View(model);
            }
        }
    }
}
