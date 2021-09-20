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
    public class DoWorkRepository : IDoWorkRepository
    {
        private readonly ApplicationDbContext _context;
        public DoWorkRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void CreateDoWork(DoWork work)
        {
            _context.Add(work);
            Save();
        }

        public void DeleteDoWork(DoWork work)
        {
            _context.Remove(work);
            Save();
        }

        public async Task<IEnumerable<DoWork>> GetDoWorksList(string search)
        {
            return await _context.DoWorks.Where(d => EF.Functions.Like(d.DoWorkTitle, $"%{search}%")).ToListAsync();
        }

        public async Task<DoWork> GetDoWorkById(int workId)
        {
            return await _context.DoWorks.SingleOrDefaultAsync(d=> d.DoWorkId == workId);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateDoWork(DoWork work)
        {
            _context.Update(work);
            Save();
        }
    }
}