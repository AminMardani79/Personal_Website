using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IProjectCategoryRepository
    {
        Task<IEnumerable<ProjectCategory>> GetProjectCategoryList(string search);
        Task<IEnumerable<ProjectCategory>> GetDeletedProjectCategoryList(string search);
        Task<ProjectCategory> GetProjectCategoryById(int categoryId);
        Task<ProjectCategory> GetDeletedProjectCategoryById(int categoryId);
        void CreateProjectCategory(ProjectCategory category);
        void UpdateProjectCategory(ProjectCategory category);
        void DeleteProjectCategory(ProjectCategory category);
        void AttachProjectCategory(ProjectCategory category);
        void Save();
    }
}
