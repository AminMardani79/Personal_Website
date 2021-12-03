using Application.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace PersonalWebsite.Components
{
    public class SkillDescViewComponent:ViewComponent
    {
        private readonly ISkillService _skillService;
        public SkillDescViewComponent(ISkillService skillService)
        {
            _skillService = skillService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("/Views/Shared/_SkillDesc.cshtml",await _skillService.GetSkill());
        }
    }
}
