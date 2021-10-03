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
            Experience model = new Experience();
            model.Date = DateTime.Now.ToShamsi();
            model.Description = experience.Description;
            model.ExperienceTitle = experience.ExperienceTitle;
            model.ExperienceType = experience.ExperienceType;
            model.GroupName = experience.GroupName;
            if(experience.ImageFile != null)
            {
                bool imageCheck = experience.ImageFile.IsImage();
                if (imageCheck)
                {
                    model.Image = ImageConvertor.SaveImage(experience.ImageFile);
                }
            }
            else
            {
                model.Image = "default.png";
            }
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
            if (experience.ImageFile != null)
            {
                bool checkImage = experience.ImageFile.IsImage();
                if (checkImage)
                {
                    ImageConvertor.RemoveImage(experience.Image);
                    model.Image = ImageConvertor.SaveImage(experience.ImageFile);
                }
            }
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
            return model;
        }

        public Tuple<List<ExperienceViewModel>, int, int> GetExperiencesList(string search, int take, int pageNumber = 1)
        {
            int skip = (pageNumber - 1) * take;
            var experienceList = _experienceRepository.GetExperiencesList(search, skip, take).Result;
            int pagesCount = PagesCount.PageCount(experienceList.Count(), take);
            List<ExperienceViewModel> models = new List<ExperienceViewModel>();
            foreach (var experience in experienceList)
            {
                models.Add(new ExperienceViewModel()
                {
                    ExperienceId = experience.ExperienceId,
                    ExperienceType = experience.ExperienceType,
                    ExperienceTitle = experience.ExperienceTitle,
                    Date = experience.Date,
                    GroupName = experience.GroupName
                });
            }
            return Tuple.Create(models, pagesCount, pageNumber);
        }
    }
}
