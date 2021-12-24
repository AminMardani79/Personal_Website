using Application.Interface;
using Application.ViewModel.ContactViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using PersonalWebsite.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = "Authorize")]
    public class MessageController : Controller
    {
        private readonly IContactMessageService _contactMessageService;
        private readonly IMessagesCountService _messagesCountService;

        public MessageController(IContactMessageService contactMessageService,
            IMessagesCountService messagesCountService)
        {
            _contactMessageService = contactMessageService;
            _messagesCountService = messagesCountService;
        }
        [HttpGet]
        [Route("/Admin/Messages/{search?}")]
        public IActionResult Index(string search, int pageNumber = 1)
        {
            int take = 6;
            var messages = _contactMessageService.GetMessagesList(search ?? "", take, pageNumber);
            _messagesCountService.ReadMessages();
            return View(messages);
        }

        [HttpGet]
        [Route("/Admin/DeleteMessage/{id}")]
        public void DeleteMessage(int id)
        {
            _contactMessageService.DeleteMessage(id);
        }
    }
}