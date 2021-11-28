using Application.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace PersonalWebsite.Components
{
    public class DoWorkViewComponent:ViewComponent
    {
        private readonly IDoWorkService _doWorkService;
        public DoWorkViewComponent(IDoWorkService doWorkService)
        {
            _doWorkService = doWorkService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("/Views/Shared/_DoWork.cshtml",await _doWorkService.ShowDoWorks());
        }
    }
}
