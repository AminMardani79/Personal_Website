using Application.ViewModel.ProjectViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IProjectService
    {
        Tuple<List<ProjectViewModel>, int, int> GetProjectsList(string search, int take, int pageNumber = 1);
        Task<EditProjectViewModel> GetProjectById(int projectId);
        void CreateProject(CreateProjectViewModel project);
        void EditProject(EditProjectViewModel project);
        void DeleteProject(int projectId);
        Task<IEnumerable<ProjectViewModel>> ShowProjects();
    }
}