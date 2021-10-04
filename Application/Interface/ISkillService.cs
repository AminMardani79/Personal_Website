using Application.ViewModel.SkillViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface ISkillService
    {
        Task<EditSkillViewModel> GetSkillById(int skillId);
        void UpdateSkill(EditSkillViewModel skill);
    }
}
