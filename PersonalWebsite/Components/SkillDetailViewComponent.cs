using Application.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace PersonalWebsite.Components
{
    public class SkillDetailViewComponent:ViewComponent
    {
        private readonly ISkillDetailService _skillDetailService;
        public SkillDetailViewComponent(ISkillDetailService skillDetailService)
        {
            _skillDetailService = skillDetailService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("/Views/Shared/_SkillDetail.cshtml",await _skillDetailService.ShowSkillDetails());
        }
    }
}
