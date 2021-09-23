using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IExperienceRepository
    {
        Task<IEnumerable<Experience>> GetExperiencesList(string search, int skip, int take);
        Task<Experience> GetExperienceById(int experienceId);
        void CreateExperience(Experience experience);
        void DeleteExperience(Experience experience);
        void UpdateExperience(Experience experience);
        void Save();
    }
}