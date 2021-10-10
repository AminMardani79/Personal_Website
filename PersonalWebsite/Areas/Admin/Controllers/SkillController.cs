using Application.Interface;
using Application.ViewModel.SkillViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SkillController : Controller
    {
        private readonly ISkillService _skillService;

        public SkillController(ISkillService skillService)
        {
            _skillService = skillService;
        }
        [HttpGet]
        [Route("/Admin/EditSkill")]
        public IActionResult EditSkill()
        {
            var skill = _skillService.GetSkill().Result;
            ViewBag.SkillId = skill.SkillId;
            return View(skill);
        }
        [HttpPost]
        [Route("/Admin/EditSkill")]
        public IActionResult EditSkill(EditSkillViewModel model)
        {
            if (ModelState.IsValid)
            {
                _skillService.UpdateSkill(model);
                return RedirectToAction("EditSkill");
            }
            else
            {
                return View(model);
            }
        }
    }
}