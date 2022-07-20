using Application.Interface;
using Application.Others;
using Application.ViewModel.ProjectCategoryViewModel;
using Application.ViewModel.ProjectViewModel;
using Domain.Interface;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly ICategoryProjectRepository _categoryProjectRepository;

        public ProjectService(IProjectRepository projectRepository,ICategoryProjectRepository categoryProjectRepository)
        {
            _projectRepository = projectRepository;
            _categoryProjectRepository = categoryProjectRepository;
        }
        public void CreateProject(CreateProjectViewModel project)
        {
            bool check = false;
            if (project.ImageFile is not null)
            {
                check = project.ImageFile.IsImage();
            }
            Project model = new Project();
            model.DownloadLink = project.DownloadLink;
            model.ProjectDescription = project.ProjectDescription;
            model.ProjectSubTitle = project.ProjectSubTitle;
            model.ProjectTitle = project.ProjectTitle;
            model.SiteUrl = project.SiteUrl;
            model.ProjectImage = project.ImageFile switch
            {
                null => "default.png",
                _ => check ? ImageConvertor.SaveImage(project.ImageFile) : "default.png"
            };
            _projectRepository.CreateProject(model);
            BuilCategoryProject(project.CategoryItems,model);
        }
        public void DeleteProject(int projectId)
        {
            var model = _projectRepository.GetProjectById(projectId).Result;
            _projectRepository.DeleteProject(model);
        }

        public void EditProject(EditProjectViewModel project)
        {
            var model = _projectRepository.GetProjectById(project.ProjectId).Result;
            var cpModel = _categoryProjectRepository.GetCategoryProjectsById(project.ProjectId).Result;
            model.DownloadLink = project.DownloadLink;
            model.ProjectDescription = project.ProjectDescription;
            model.ProjectSubTitle = project.ProjectSubTitle;
            model.ProjectTitle = project.ProjectTitle;
            model.SiteUrl = project.SiteUrl;
            if (project.ImageFile != null)
            {
                bool checkImage = project.ImageFile.IsImage();
                if (checkImage)
                {
                    ImageConvertor.RemoveImage(project.ProjectImage);
                    model.ProjectImage = ImageConvertor.SaveImage(project.ImageFile);
                }
            }
            _projectRepository.UpdateProject(model);
            _categoryProjectRepository.RemoveAll(cpModel);
            BuilCategoryProject(project.CategoryItems,model);
        }

        public async Task<EditProjectViewModel> GetProjectById(int projectId)
        {
            var project = await _projectRepository.GetProjectById(projectId);
            EditProjectViewModel model = new EditProjectViewModel();
            model.DownloadLink = project.DownloadLink;
            model.ProjectDescription = project.ProjectDescription;
            model.ProjectSubTitle = project.ProjectSubTitle;
            model.ProjectTitle = project.ProjectTitle;
            model.ProjectId = project.ProjectId;
            model.ProjectImage = project.ProjectImage;
            model.SiteUrl = project.SiteUrl;
            return model;
        }

        public Tuple<List<ProjectViewModel>, int, int> GetProjectsList(string search, int take, int pageNumber = 1)
        {
            int skip = (pageNumber - 1) * take;
            var projectList = _projectRepository.GetProjectsList(search, skip, take).Result;
            var projectsCount = _projectRepository.GetProjectsCount().Result;
            int pagesCount = PagesCount.PageCount(projectsCount, take);
            var models = new List<ProjectViewModel>();
            foreach (var project in projectList)
            {
                var categoryModels = new List<ProjectCategoryViewModel>();
                var categories = _categoryProjectRepository.GetCategoryProjectsById(project.ProjectId).Result;
                foreach (var category in categories)
                {
                    categoryModels.Add(new ProjectCategoryViewModel
                    {
                        CategoryTitle = category.ProjectCategory.CategoryTitle
                    });
                }
                models.Add(new ProjectViewModel()
                {
                    ProjectId = project.ProjectId,
                    ProjectSubTitle = project.ProjectSubTitle,
                    ProjectTitle = project.ProjectTitle,
                    ProjectImage = project.ProjectImage,
                    Categories = categoryModels
                });
            }
            return Tuple.Create(models, pagesCount, pageNumber);
        }
        public async Task<IEnumerable<ProjectViewModel>> ShowProjects()
        {
            var projectList = await _projectRepository.ShowProjects();
            var models = new List<ProjectViewModel>();
            foreach (var project in projectList)
            {
                var categoryModels = new List<ProjectCategoryViewModel>();
                var categories = await _categoryProjectRepository.GetCategoryProjectsById(project.ProjectId);
                foreach (var category in categories)
                {
                    categoryModels.Add(new ProjectCategoryViewModel
                    {
                        CategoryFilter = category.ProjectCategory.CategoryFilter
                    });
                }
                models.Add(new ProjectViewModel()
                {
                    ProjectId = project.ProjectId,
                    ProjectSubTitle = project.ProjectSubTitle,
                    ProjectTitle = project.ProjectTitle,
                    ProjectImage = project.ProjectImage,
                    Categories = categoryModels,
                    DownloadLink = project.DownloadLink,
                    SiteUrl = project.SiteUrl
                });
            }
            return models;
        }

        #region Private Methods

        private void BuilCategoryProject(List<int> CategoryItems, Project model)
        {
            if (CategoryItems.Count is not 0)
            {
                var cpModels = new List<CategoryProject>();
                foreach (var item in CategoryItems)
                {
                    cpModels.Add(new()
                    {
                        ProjectId = model.ProjectId,
                        CategoryId = item
                    });
                }
                _categoryProjectRepository.CreateCPModels(cpModels);
            }
        }

        #endregion
    }
}
