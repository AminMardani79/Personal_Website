using Application.Interface;
using Application.ViewModel.AboutMeViewModel;
using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AboutService : IAboutService
    {
        private readonly IAboutRepository _aboutRepository;
        public AboutService(IAboutRepository aboutRepository)
        {
            _aboutRepository = aboutRepository;
        }
        public async Task<EditAboutMeViewModel> GetAboutById(int aboutId)
        {
            var about = await _aboutRepository.GetAboutById(aboutId);
            EditAboutMeViewModel model = new EditAboutMeViewModel();
            model.AboutMeContext = about.AboutMeContext;
            model.AboutMeDes = about.AboutMeDes;
            model.AboutMeId = about.AboutMeId;
            model.CustomerCount = about.CustomerCount;
            model.ProjectsCount = about.ProjectsCount;
            return model;
        }

        public void UpdateAbout(EditAboutMeViewModel about)
        {
            var model = _aboutRepository.GetAboutById(about.AboutMeId).Result;
            model.AboutMeContext = about.AboutMeContext;
            model.AboutMeDes = about.AboutMeDes;
            model.CustomerCount = about.CustomerCount;
            model.ProjectsCount = about.ProjectsCount;
            _aboutRepository.UpdateAbout(model);
        }
    }
}
