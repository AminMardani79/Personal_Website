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
        public async Task<EditSkillViewModel> GetSkillById(int skillId)
        {
            var skill = await _skillRepository.GetSkillById(skillId);
            EditSkillViewModel model = new EditSkillViewModel();
            model.SkillDescription = skill.SkillDescription;
            model.SkillId = skillId;
            return model;
        }

        public void UpdateSkill(EditSkillViewModel skill)
        {
            var model = _skillRepository.GetSkillById(skill.SkillId).Result;
            model.SkillDescription = skill.SkillDescription;
            _skillRepository.UpdateSkill(model);
        }
    }
}
