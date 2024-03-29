﻿using Application.Interface;
using Application.ViewModel.ProfileViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace PersonalWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = "Authorize")]
    public class ProfileImageController : Controller
    {
        private readonly IProfileService _profileService;
        public ProfileImageController(IProfileService profileService)
        {
            _profileService = profileService;
        }
        [HttpGet]
        [Route("/Admin/EditProfile")]
        public IActionResult EditProfile()
        {
            var profile = _profileService.GetProfile().Result;
            return View(profile);
        }
        [HttpPost]
        [Route("/Admin/EditProfile")]
        public async Task<IActionResult> EditProfile(EditProfileViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await _profileService.UpdateProfile(model);
            return RedirectToAction("EditProfile","ProfileImage");
        }
    }
}
