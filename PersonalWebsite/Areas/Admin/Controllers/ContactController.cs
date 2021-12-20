using Application.Interface;
using Application.ViewModel.ContactViewModel;
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
    public class ContactController : Controller
    {
        private readonly IContactDetailService _contactDetailService;

        public ContactController(IContactDetailService contactDetailService)
        {
            _contactDetailService = contactDetailService;
        }
        [HttpGet]
        [Route("/Admin/EditContact")]
        public IActionResult EditContact()
        {
            var contact = _contactDetailService.GetContactDetail().Result;
            return View(contact);
        }
        [HttpPost]
        [Route("/Admin/EditContact")]
        public IActionResult EditContact(EditContactDetailViewModel model)
        {
            if (ModelState.IsValid)
            {
                _contactDetailService.UpdateContactDetail(model);
                return RedirectToAction("EditContact");
            }
            else
            {
                return View(model);
            }
        }
    }
}