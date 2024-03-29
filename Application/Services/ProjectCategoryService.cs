﻿using Application.Interface;
using Application.Others;
using Application.ViewModel.ProjectCategoryViewModel;
using Domain.Interface;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProjectCategoryService : IProjectCategoryService
    {
        private readonly IProjectCategoryRepository _projectCategoryRepository;
        public ProjectCategoryService(IProjectCategoryRepository projectCategoryRepository)
        {
            _projectCategoryRepository = projectCategoryRepository;
        }

        public void CreateProjectCategory(CreateProjectCategoryViewModel projectCategory)
        {
            ProjectCategory model = new ProjectCategory();
            model.CategoryTitle = projectCategory.CategoryTitle;
            model.CategoryFilter = projectCategory.CategoryFilter;
            _projectCategoryRepository.CreateProjectCategory(model);
        }

        public void DeleteProjectCategory(int projectCategoryId)
        {
            var model = _projectCategoryRepository.GetDeletedProjectCategoryById(projectCategoryId).Result;
            _projectCategoryRepository.DeleteProjectCategory(model);
        }
        public void AddCategoryToTrashList(int projectCategoryId)
        {
            var model = _projectCategoryRepository.GetProjectCategoryById(projectCategoryId).Result;
            model.IsCategoryDelete = true;
            _projectCategoryRepository.AttachProjectCategory(model);
        }

        public void BackToList(int projectCategoryId)
        {
            var model = _projectCategoryRepository.GetDeletedProjectCategoryById(projectCategoryId).Result;
            model.IsCategoryDelete = false;
            _projectCategoryRepository.AttachProjectCategory(model);
        }

        public void EditProjectCategory(EditProjectCategoryViewModel projectCategory)
        {
            var model = _projectCategoryRepository.GetProjectCategoryById(projectCategory.CategoryId).Result;
            model.CategoryTitle = projectCategory.CategoryTitle;
            model.CategoryFilter = projectCategory.CategoryFilter;
            _projectCategoryRepository.UpdateProjectCategory(model);
        }

        public async Task<EditProjectCategoryViewModel> GetDeletedProjectCategoryById(int projectCategoryId)
        {
            var category = await _projectCategoryRepository.GetDeletedProjectCategoryById(projectCategoryId);
            EditProjectCategoryViewModel model = new EditProjectCategoryViewModel();
            model.CategoryId = category.CategoryId;
            model.CategoryTitle = category.CategoryTitle;
            model.CategoryFilter = category.CategoryFilter;
            return model;
        }

        public async Task<List<ProjectCategoryViewModel>> GetDeletedProjectCategoryList(string search)
        {
            var categoryList = await _projectCategoryRepository.GetDeletedProjectCategoryList(search);
            List<ProjectCategoryViewModel> models = new List<ProjectCategoryViewModel>();
            foreach (var category in categoryList)
            {
                models.Add(new ProjectCategoryViewModel()
                {
                    CategoryId = category.CategoryId,
                    CategoryTitle = category.CategoryTitle,
                    CategoryFilter = category.CategoryFilter,
                });
            }
            return models;
        }

        public async Task<EditProjectCategoryViewModel> GetProjectCategoryById(int projectCategoryId)
        {
            var category = await _projectCategoryRepository.GetProjectCategoryById(projectCategoryId);
            EditProjectCategoryViewModel model = new EditProjectCategoryViewModel();
            model.CategoryId = category.CategoryId;
            model.CategoryTitle = category.CategoryTitle;
            model.CategoryFilter = category.CategoryFilter;
            return model;
        }

        public async Task<IEnumerable<ProjectCategoryViewModel>> GetProjectCategoryList(string search)
        {
            var categoryList = await _projectCategoryRepository.GetProjectCategoryList(search);
            List<ProjectCategoryViewModel> models = new List<ProjectCategoryViewModel>();
            foreach (var category in categoryList)
            {
                models.Add(new ProjectCategoryViewModel()
                {
                    CategoryId = category.CategoryId,
                    CategoryTitle = category.CategoryTitle,
                    CategoryFilter= category.CategoryFilter,
                });
            }
            return models;
        }
        public async Task<IEnumerable<ProjectCategoryViewModel>> GetProjectCategoryList()
        {
            var categoryList = await _projectCategoryRepository.GetProjectCategoryList();
            List<ProjectCategoryViewModel> models = new List<ProjectCategoryViewModel>();
            foreach (var category in categoryList)
            {
                models.Add(new ProjectCategoryViewModel()
                {
                    CategoryId = category.CategoryId,
                    CategoryTitle = category.CategoryTitle,
                    CategoryFilter = category.CategoryFilter,
                });
            }
            return models;
        }
        public async Task<List<ProjectCategoryViewModel>> ShowCategories()
        {
            var categoryList = await _projectCategoryRepository.GetProjectCategoryList();
            List<ProjectCategoryViewModel> models = new List<ProjectCategoryViewModel>();
            foreach (var category in categoryList)
            {
                models.Add(new ProjectCategoryViewModel()
                {
                    CategoryTitle = category.CategoryTitle,
                    CategoryFilter = category.CategoryFilter,
                });
            }
            return models;
        }
    }
}