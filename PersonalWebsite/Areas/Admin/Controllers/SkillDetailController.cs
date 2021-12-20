using Application.Interface;
using Application.ViewModel.SkillViewModel;
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
    public class SkillDetailController : Controller
    {
        private readonly ISkillDetailService _skillDetailService;
        public SkillDetailController(ISkillDetailService skillDetailService)
        {
            _skillDetailService = skillDetailService;
        }
        [HttpGet]
        [Route("/Admin/Skill/Details/{id}/{search?}")]
        public IActionResult Index(int id,string search, int pageNumber = 1)
        {
            ViewBag.SkillId = id;
            int take = 6;
            var details = _skillDetailService.GetSkillDetailsList(search ?? "", take, pageNumber);
            return View(details);
        }
        [HttpGet]
        [Route("/Admin/CreateDetail/{id}")]
        public IActionResult CreateDetail(int id)
        {
            ViewBag.SkillId = id;
            return View();
        }

        [HttpPost]
        [Route("/Admin/CreateDetail/{id}")]
        public IActionResult CreateDetail(CreateSkillDetailViewModel model)
        {
            if (ModelState.IsValid)
            {
                _skillDetailService.CreateSkillDetail(model);
                return Redirect($"/Admin/Skill/Details/{model.SkillId}");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        [Route("/Admin/EditDetail/{id}/{skillId}")]
        public IActionResult EditDetail(int id,int skillId)
        {
            ViewBag.SkillId = skillId;
            var model = _skillDetailService.GetSkillDetailById(id).Result;
            return View(model);
        }

        [HttpPost]
        [Route("/Admin/EditDetail/{id}/{skillId}")]
        public IActionResult EditDetail(EditSkillDetailViewModel model)
        {
            if (ModelState.IsValid)
            {
                _skillDetailService.EditSkillDetail(model);
                return Redirect($"/Admin/Skill/Details/{model.SkillId}");
            }
            else
            {
                return View(model);
            }
        }
        [HttpGet]
        [Route("/Admin/DeleteDetail/{id}")]
        public void DeleteDetail(int id)
        {
            _skillDetailService.DeleteSkillDetail(id);
        }
    }
}