using Application.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace PersonalWebsite.Components
{
    public class MessagesViewComponent:ViewComponent
    {
        private readonly IContactMessageService _contactMessageService;

        public MessagesViewComponent(IContactMessageService contactMessageService)
        {
            _contactMessageService = contactMessageService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("/Views/Shared/_Messages.cshtml",await _contactMessageService.ShowActiveMessages());
        }
    }
}
