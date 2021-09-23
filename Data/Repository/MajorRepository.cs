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
    public class MajorRepository:IMajorRepository
    {
        private readonly ApplicationDbContext _context;
        public MajorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreateMajor(Major major)
        {
            _context.Add(major);
            Save();
        }

        public void DeleteMajor(Major major)
        {
            _context.Remove(major);
            Save();
        }

        public async Task<Major> GetMajorById(int majorId)
        {
            return await _context.Majors.SingleOrDefaultAsync(m=> m.MajorId == majorId);
        }

        public async Task<IEnumerable<Major>> GetMajoresList(string search, int skip, int take)
        {
            return await _context.Majors.Where(m=> EF.Functions.Like(m.MajorTitle,$"%{search}%")).Skip(skip).Take(take).ToListAsync();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateMajor(Major major)
        {
            _context.Update(major);
            Save();
        }
    }
}
