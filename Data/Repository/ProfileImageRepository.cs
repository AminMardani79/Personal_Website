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
    public class ProfileImageRepository : IProfileImageRepository
    {
        private readonly ApplicationDbContext _context;
        public ProfileImageRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ProfileImage> GetProfileImageAsync()
        {
            return await _context.ProfileImage.FirstOrDefaultAsync();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateProfile(ProfileImage image)
        {
            _context.Update(image);
            Save();
        }
    }
}
