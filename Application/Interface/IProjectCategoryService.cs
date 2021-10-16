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
        Task<IEnumerable<ProjectCategoryViewModel>> GetProjectCategoryList(string search);
        Task<IEnumerable<ProjectCategoryViewModel>> GetProjectCategoryList();
        Task<List<ProjectCategoryViewModel>> GetDeletedProjectCategoryList(string search);
        Task<EditProjectCategoryViewModel> GetProjectCategoryById(int projectCategoryId);
        Task<EditProjectCategoryViewModel> GetDeletedProjectCategoryById(int projectCategoryId);
        void CreateProjectCategory(CreateProjectCategoryViewModel projectCategory);
        void EditProjectCategory(EditProjectCategoryViewModel projectCategory);
        void DeleteProjectCategory(int projectCategoryId);
        void AddCategoryToTrashList(int projectCategoryId);
        void BackToList(int projectCategoryId);
    }
}