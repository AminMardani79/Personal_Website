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
    public class ExperienceRepository : IExperienceRepository
    {
        private readonly ApplicationDbContext _context;
        public ExperienceRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void CreateExperience(Experience experience)
        {
            _context.Add(experience);
            Save();
        }

        public void DeleteExperience(Experience experience)
        {
            _context.Remove(experience);
            Save();
        }

        public async Task<Experience> GetExperienceById(int experienceId)
        {
            return await _context.Experiences.SingleOrDefaultAsync(e=> e.ExperienceId == experienceId);
        }

        public async Task<IEnumerable<Experience>> GetExperiencesList(string search)
        {
            return await _context.Experiences.Where(e=> EF.Functions.Like(e.ExperienceTitle,$"%{search}%")).ToListAsync();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateExperience(Experience experience)
        {
            _context.Update(experience);
            Save();
        }
    }
}
