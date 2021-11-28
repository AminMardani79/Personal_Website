using Application.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace PersonalWebsite.Components
{
    public class AboutMeViewComponent:ViewComponent
    {
        private readonly IAboutService _aboutService;
        public AboutMeViewComponent(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("/Views/Shared/_AboutMe.cshtml",await _aboutService.GetAbout());
        }
    }
}
