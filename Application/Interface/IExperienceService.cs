using Application.ViewModel.ExperienceViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IExperienceService
    {
        Tuple<List<ExperienceViewModel>, int, int> GetExperiencesList(string search, int take, int pageNumber = 1);
        Task<EditExperienceViewModel> GetExperienceById(int experienceId);
        void CreateExperience(CreateExperienceViewModel experience);
        void EditExperience(EditExperienceViewModel experience);
        void DeleteExperience(int experienceId);
    }
}