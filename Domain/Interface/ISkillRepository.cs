using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface ISkillRepository
    {
        Task<Skill> GetSkillById(int skillId);
        void UpdateSkill(Skill skill);
        void Save();
    }
}
