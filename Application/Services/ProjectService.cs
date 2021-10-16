using Application.Interface;
using Application.Others;
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
        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public void CreateProject(CreateProjectViewModel project)
        {
            Project model = new Project();
            model.DownloadLink = project.DownloadLink;
            model.ProjectDescription = project.ProjectDescription;
            model.ProjectSubTitle = project.ProjectSubTitle;
            model.ProjectTitle = project.ProjectTitle;
            model.CategoryId = project.CategoryId;
            if (project.ImageFile != null)
            {
                bool check = project.ImageFile.IsImage();
                if (check)
                {
                    model.ProjectImage = ImageConvertor.SaveImage(project.ImageFile);
                }
                else
                {
                    model.ProjectImage = "default.png";
                }
            }
            else
            {
                model.ProjectImage = "default.png";
            }
            _projectRepository.CreateProject(model);
        }

        public void DeleteProject(int projectId)
        {
            var model = _projectRepository.GetProjectById(projectId).Result;
            _projectRepository.DeleteProject(model);
        }

        public void EditProject(EditProjectViewModel project)
        {
            var model = _projectRepository.GetProjectById(project.ProjectId).Result;
            model.DownloadLink = project.DownloadLink;
            model.ProjectDescription = project.ProjectDescription;
            model.ProjectSubTitle = project.ProjectSubTitle;
            model.ProjectTitle = project.ProjectTitle;
            model.CategoryId = project.CategoryId;
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
            model.CategoryId = project.CategoryId;
            model.ProjectImage = project.ProjectImage;
            return model;
        }

        public Tuple<List<ProjectViewModel>, int, int> GetProjectsList(string search, int take, int pageNumber = 1)
        {
            int skip = (pageNumber - 1) * take;
            var projectList = _projectRepository.GetProjectsList(search, skip, take).Result;
            int pagesCount = PagesCount.PageCount(projectList.Count(), take);
            List<ProjectViewModel> models = new List<ProjectViewModel>();
            foreach (var project in projectList)
            {
                models.Add(new ProjectViewModel()
                {
                    ProjectId = project.ProjectId,
                    ProjectSubTitle = project.ProjectSubTitle,
                    ProjectTitle = project.ProjectTitle,
                    ProjectImage = project.ProjectImage,
                    CategoryId = project.CategoryId,
                    CategoryTitle = project.ProjectCategory.CategoryTitle
                });
            }
            return Tuple.Create(models, pagesCount, pageNumber);
        }
    }
}
