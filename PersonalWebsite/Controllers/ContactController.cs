using Application.Interface;
using Application.ViewModel.ContactViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWebsite.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactMessageService _contactMessageService;
        public ContactController(IContactMessageService contactMessageService)
        {
            _contactMessageService = contactMessageService;
        }
        [HttpGet]
        [Route("/SendMessage")]
        public void SendMessage(string name,string subject,string message,string email,string number)
        {
            if(name == null || subject ==null || message == null)
            {
                Redirect("/");
            }
            else
            {
                CreateContactMessageViewModel model = new CreateContactMessageViewModel()
                {
                    UserName = name,
                    MessageTitle = subject,
                    MessageDescription = message,
                    UserNumber = number,
                    UserEmail = email
                };
                _contactMessageService.CreateMessage(model);
            }
        }
        [Route("/ShowMessage")]
        public async Task ShowMessage(int id)
        {
           await _contactMessageService.AttachMessage(id);
        }
    }
}
