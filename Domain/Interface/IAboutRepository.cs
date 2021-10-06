using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IAboutRepository
    {
        Task<AboutMe> GetAbout();
        void UpdateAbout(AboutMe about);
        void Save();
    }
}