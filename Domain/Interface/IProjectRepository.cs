using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> GetProjectsList(string search, int skip, int take);
        Task<Project> GetProjectById(int projectId);
        void CreateProject(Project project);
        void DeleteProject(Project project);
        void UpdateProject(Project project);
        void Save();
        Task<IEnumerable<Project>> ShowProjects();
        Task<int> GetProjectsCount();
    }
}
