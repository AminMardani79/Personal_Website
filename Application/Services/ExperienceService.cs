using Application.Interface;
using Application.Others;
using Application.ViewModel.ExperienceViewModel;
using Domain.Interface;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ExperienceService : IExperienceService
    {
        private readonly IExperienceRepository _experienceRepository;
        public ExperienceService(IExperienceRepository experienceRepository)
        {
            _experienceRepository = experienceRepository;
        }
        public void CreateExperience(CreateExperienceViewModel experience)
        {
            bool imageCheck = experience.ImageFile.IsImage();
            Experience model = new Experience();
            model.Date = experience.Date;
            model.Description = experience.Description;
            model.ExperienceTitle = experience.ExperienceTitle;
            model.ExperienceType = experience.ExperienceType;
            model.GroupName = experience.GroupName;
            model.Image = experience.ImageFile switch
            {
                null => "default.png",
                _ => imageCheck ? ImageConvertor.SaveImage(experience.ImageFile) : null
            };
            _experienceRepository.CreateExperience(model);
        }

        public void DeleteExperience(int experienceId)
        {
            var experience = _experienceRepository.GetExperienceById(experienceId).Result;
            _experienceRepository.DeleteExperience(experience);
        }

        public void EditExperience(EditExperienceViewModel experience)
        {
            var model = _experienceRepository.GetExperienceById(experience.ExperienceId).Result;
            model.ExperienceType = experience.ExperienceType;
            model.ExperienceTitle = experience.ExperienceTitle;
            model.Description = experience.Description;
            model.GroupName = experience.GroupName;
            model.Date = experience.Date;
            if (experience.ImageFile != null)
            {
                bool checkImage = experience.ImageFile.IsImage();
                if (checkImage)
                {
                    ImageConvertor.RemoveImage(experience.Image);
                    model.Image = ImageConvertor.SaveImage(experience.ImageFile);
                }
            }
            _experienceRepository.UpdateExperience(model);
        }

        public async Task<EditExperienceViewModel> GetExperienceById(int experienceId)
        {
            var experience = await _experienceRepository.GetExperienceById(experienceId);
            EditExperienceViewModel model = new EditExperienceViewModel();
            model.ExperienceType = experience.ExperienceType;
            model.ExperienceTitle = experience.ExperienceTitle;
            model.Description = experience.Description;
            model.GroupName = experience.GroupName;
            model.Image = experience.Image;
            model.Date = experience.Date;
            model.ExperienceId = experience.ExperienceId;
            return model;
        }

        public Tuple<List<ExperienceViewModel>, int, int> GetExperiencesList(string search, int take, int pageNumber = 1)
        {
            int skip = (pageNumber - 1) * take;
            var experienceList = _experienceRepository.GetExperiencesList(search, skip, take).Result;
            var experiencesCount = _experienceRepository.GetExperiencesCount().Result;
            int pagesCount = PagesCount.PageCount(experiencesCount, take);
            List<ExperienceViewModel> models = new List<ExperienceViewModel>();
            foreach (var experience in experienceList)
            {
                models.Add(new ExperienceViewModel()
                {
                    ExperienceId = experience.ExperienceId,
                    ExperienceType = experience.ExperienceType,
                    ExperienceTitle = experience.ExperienceTitle,
                    Date = experience.Date,
                    GroupName = experience.GroupName,
                    Image = experience.Image
                });
            }
            return Tuple.Create(models, pagesCount, pageNumber);
        }
        public async Task<IEnumerable<ExperienceViewModel>> ShowExperiences()
        {
            var experiences = await _experienceRepository.ShowExperiences();
            var list = new List<ExperienceViewModel>();
            foreach (var item in experiences)
            {
                list.Add(new()
                {
                    ExperienceType = item.ExperienceType,
                    ExperienceTitle = item.ExperienceTitle,
                    Date = item.Date,
                    GroupName = item.GroupName,
                    Image = item.Image
                });
            }
            return list;
        }
    }
}
