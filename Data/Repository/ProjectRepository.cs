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
    public class ProjectRepository : IProjectRepository
    {
        private readonly ApplicationDbContext _context;
        public ProjectRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void CreateProject(Project project)
        {
            _context.Add(project);
            Save();
        }

        public void DeleteProject(Project project)
        {
            _context.Remove(project);
            Save();
        }

        public async Task<Project> GetProjectById(int projectId)
        {
            return await _context.Projects.SingleOrDefaultAsync(p=> p.ProjectId == projectId);
        }

        public async Task<IEnumerable<Project>> GetProjectsList(string search, int skip, int take)
        {
            return await _context.Projects.Where(p => EF.Functions.Like(p.ProjectTitle, $"%{search}%")).Skip(skip).Take(take).ToListAsync();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateProject(Project project)
        {
            _context.Update(project);
            Save();
        }
        public async Task<IEnumerable<Project>> ShowProjects()
        {
            return await _context.Projects.ToListAsync();
        }
    }
}
