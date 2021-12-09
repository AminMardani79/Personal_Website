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
    public class CategoryProjectRepository : ICategoryProjectRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryProjectRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void CreateCPModels(List<CategoryProject> model)
        {
            _context.AddRange(model);
            Save();
        }

        public async Task<IEnumerable<CategoryProject>> GetCategoryProjectsById(int projectId)
        {
            return await _context.CategoryProjects.Include(c=> c.ProjectCategory).Where(c => c.ProjectId == projectId).ToListAsync();
        }

        public async Task<IEnumerable<int>> GetSelectedCategoryIds(int projectId)
        {
            return await _context.CategoryProjects.Where(c => c.ProjectId == projectId).Select(c => c.CategoryId).ToListAsync();
        }

        public void RemoveAll(IEnumerable<CategoryProject> cpModel)
        {
            _context.RemoveRange(cpModel);
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
