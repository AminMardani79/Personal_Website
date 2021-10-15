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
    public class ProjectCategoryRepository : IProjectCategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public ProjectCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void CreateProjectCategory(ProjectCategory category)
        {
            _context.Add(category);
            Save();
        }

        public void DeleteProjectCategory(ProjectCategory category)
        {
            _context.Remove(category);
            Save();
        }
        public void AttachProjectCategory(ProjectCategory category)
        {
            _context.Attach(category);
            Save();
        }

        public async Task<ProjectCategory> GetDeletedProjectCategoryById(int categoryId)
        {
            return await _context.ProjectCategorys.Where(p=> p.IsCategoryDelete == true).IgnoreQueryFilters().SingleOrDefaultAsync(p=> p.CategoryId == categoryId);
        }

        public async Task<List<ProjectCategory>> GetDeletedProjectCategoryList(string search)
        {
            return await _context.ProjectCategorys.Where(p=> EF.Functions.Like(p.CategoryTitle,$"%{search}%") && p.IsCategoryDelete == true).IgnoreQueryFilters().ToListAsync();
        }

        public async Task<ProjectCategory> GetProjectCategoryById(int categoryId)
        {
            return await _context.ProjectCategorys.SingleOrDefaultAsync(p=> p.CategoryId == categoryId);
        }

        public async Task<List<ProjectCategory>> GetProjectCategoryList(string search)
        {
            return await _context.ProjectCategorys.Where(p => EF.Functions.Like(p.CategoryTitle, $"%{search}%")).ToListAsync();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateProjectCategory(ProjectCategory category)
        {
            _context.Update(category);
            Save();
        }
    }
}
