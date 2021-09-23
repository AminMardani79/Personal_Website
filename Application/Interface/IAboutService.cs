using Application.ViewModel.AboutMeViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IAboutService
    {
        Task<EditAboutMeViewModel> GetAboutById(int aboutId);
        void UpdateAbout(EditAboutMeViewModel about);
    }
}
