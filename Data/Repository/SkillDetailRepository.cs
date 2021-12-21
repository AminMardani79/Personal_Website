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
    public class SkillDetailRepository : ISkillDetailRepository
    {
        private readonly ApplicationDbContext _context;
        public SkillDetailRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void CreateSkillDetail(SkillDetail skillDetail)
        {
            _context.Add(skillDetail);
            Save();
        }

        public void DeleteSkillDetail(SkillDetail skillDetail)
        {
            _context.Remove(skillDetail);
            Save();
        }

        public async Task<SkillDetail> GetSkillDetailById(int skillDetailId)
        {
            return await _context.SkillDetails.SingleOrDefaultAsync(s=> s.SkillDetailId == skillDetailId);
        }

        public async Task<IEnumerable<SkillDetail>> GetSkillDetailsList(string search, int skip, int take)
        {
            return await _context.SkillDetails.Where(s => EF.Functions.Like(s.SkillTitle, $"%{search}%")).Skip(skip).Take(take).ToListAsync();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateSkillDetail(SkillDetail skillDetail)
        {
            _context.Update(skillDetail);
            Save();
        }
        public async Task<IEnumerable<SkillDetail>> ShowSkillDetails()
        {
            return await _context.SkillDetails.OrderBy(s => s.SkillDetailId).ToListAsync();
        }
        public async Task<int> GetSkillsCount()
        {
            return await _context.SkillDetails.CountAsync();
        }
    }
}
