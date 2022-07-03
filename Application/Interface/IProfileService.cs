using Application.ViewModel.ProfileViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IProfileService
    {
        void UpdateProfile(EditProfileViewModel model);
        Task<EditProfileViewModel> GetProfile();
    }
}
