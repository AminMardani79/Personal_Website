using Application.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace PersonalWebsite.Components
{
    public class MajorViewComponent:ViewComponent
    {
        private readonly IMajorService _majorService;

        public MajorViewComponent(IMajorService majorService)
        {
            _majorService = majorService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("/Views/Shared/_Major.cshtml", await _majorService.ShowMajors());
        }
    }
}
