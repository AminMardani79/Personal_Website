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
        Task<IEnumerable<Project>> GetProjectsList(string search);
        Task<Project> GetProjectById(int projectId);
        void CreateProject(Project project);
        void DeleteProject(Project project);
        void UpdateProject(Project project);
        void Save();
    }
}
