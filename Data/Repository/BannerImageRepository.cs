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
    public class BannerImageRepository:IBannerImageRepository
    {
        private readonly ApplicationDbContext _context;
        public BannerImageRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<BannerImage> GetBannerImageAsync()
        {
            return await _context.BannerImage.FirstOrDefaultAsync();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateBanner(BannerImage image)
        {
            _context.Update(image);
            Save();
        }
    }
}
