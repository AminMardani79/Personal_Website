using Data.ApplicationContext;
using Domain.Interface;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class SkillRepository : ISkillRepository
    {
        private readonly ApplicationDbContext _context;
        public SkillRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Skill> GetSkillById(int skillId)
        {
            return await _context.Skills.SingleOrDefaultAsync(s=> s.SkillId == skillId);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateSkill(Skill skill)
        {
            _context.Update(skill);
            Save();
        }
    }
}
