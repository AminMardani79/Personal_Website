using Application.Interface;
using Application.ViewModel.ContactViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using PersonalWebsite.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWebsite.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactMessageService _contactMessageService;
        private readonly IHubContext<NotificationHub> _notifHub;
        public ContactController(IContactMessageService contactMessageService, IHubContext<NotificationHub> notifHub)
        {
            _contactMessageService = contactMessageService;
            _notifHub = notifHub;
        }
        [HttpGet]
        [Route("/SendMessage")]
        public async void SendMessage(string name,string subject,string message,string email,string number)
        {
            if(name == null || subject ==null || message == null)
            {
                Redirect("/");
            }
            else
            {
                var model = new CreateContactMessageViewModel()
                {
                    UserName = name,
                    MessageTitle = subject,
                    MessageDescription = message,
                    UserNumber = number,
                    UserEmail = email
                };
                _contactMessageService.CreateMessage(model);
                await _notifHub.Clients.All.SendAsync("CountNewMessage");
            }
        }
        [Route("/ShowMessage")]
        public async Task ShowMessage(int id)
        {
           await _contactMessageService.AttachMessage(id);
        }
    }
}
