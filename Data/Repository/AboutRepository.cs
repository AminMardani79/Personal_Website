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
    public class AboutRepository : IAboutRepository
    {
        private readonly ApplicationDbContext _context;
        public AboutRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<AboutMe> GetAboutById(int aboutId)
        {
            return await _context.AboutMe.SingleOrDefaultAsync(a=> a.AboutMeId == aboutId);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateAbout(AboutMe about)
        {
            _context.Update(about);
            Save();
        }
    }
}
