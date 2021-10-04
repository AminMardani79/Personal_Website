using Application.ViewModel.ProjectCategoryViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IProjectCategoryService
    {
        Task<List<ProjectCategoryViewModel>> GetProjectCategoryList(string search);
        Task<List<ProjectCategoryViewModel>> GetDeletedProjectCategoryList(string search);
        Task<EditProjectCategoryViewModel> GetProjectCategoryById(int projectCategoryId);
        Task<EditProjectCategoryViewModel> GetDeletedProjectCategoryById(int projectCategoryId);
        void CreateProjectCategory(CreateProjectCategoryViewModel projectCategory);
        void EditProjectCategory(EditProjectCategoryViewModel projectCategory);
        void DeleteProjectCategory(int projectCategoryId);
    }
}