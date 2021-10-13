using Application.Interface;
using Application.ViewModel.DoWorkViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DoWorkController : Controller
    {
        private readonly IDoWorkService _doWorkService;
        public DoWorkController(IDoWorkService doWorkService)
        {
            _doWorkService = doWorkService;
        }
        [HttpGet]
        [Route("/Admin/DoWorks/{search?}")]
        public IActionResult Index(string search, int pageNumber = 1)
        {
            int take = 6;
            var doWorks = _doWorkService.GetDoWorksList(search ?? "", take, pageNumber);
            return View(doWorks);
        }
        [HttpGet]
        [Route("/Admin/CreateDoWork")]
        public IActionResult CreateDoWork()
        {
            return View();
        }

        [HttpPost]
        [Route("/Admin/CreateDoWork")]
        public IActionResult CreateDoWork(CreateDoWorkViewModel model)
        {
            if (ModelState.IsValid)
            {
                _doWorkService.CreateDoWork(model);
                return Redirect($"/Admin/DoWorks");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        [Route("/Admin/EditDoWork/{id}")]
        public IActionResult EditDoWork(int id)
        {
            var model = _doWorkService.GetDoWorkById(id).Result;
            return View(model);
        }
        
        [HttpPost]
        [Route("/Admin/EditDoWork/{id}")]
        public IActionResult EditDoWork(EditDoWorkViewModel model)
        {
            if (ModelState.IsValid)
            {
                _doWorkService.EditDoWork(model);
                return Redirect($"/Admin/DoWorks");
            }
            else
            {
                return View(model);
            }
        }
        [HttpGet]
        [Route("/Admin/DeleteDoWork/{id}")]
        public void DeleteDoWork(int id)
        {
            _doWorkService.DeleteDoWork(id);
        }
    }
}
