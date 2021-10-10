using Application.Interface;
using Application.ViewModel.SkillViewModel;
using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class SkillService : ISkillService
    {
        private readonly ISkillRepository _skillRepository;
        public SkillService(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }
        public async Task<EditSkillViewModel> GetSkill()
        {
            var skill = await _skillRepository.GetSkill();
            EditSkillViewModel model = new EditSkillViewModel();
            model.SkillDescription = skill.SkillDescription;
            model.SkillId = skill.SkillId;
            return model;
        }

        public void UpdateSkill(EditSkillViewModel skill)
        {
            var model = _skillRepository.GetSkill().Result;
            model.SkillDescription = skill.SkillDescription;
            _skillRepository.UpdateSkill(model);
        }
    }
}
