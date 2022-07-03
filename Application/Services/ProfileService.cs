﻿using Application.Interface;
using Application.Others;
using Application.ViewModel.ProfileViewModel;
using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileImageRepository _profileRepositoy;
        public ProfileService(IProfileImageRepository profileRepository)
        {
            _profileRepositoy = profileRepository;
        }

        public async Task<EditProfileViewModel> GetProfile()
        {
            var profile = await _profileRepositoy.GetProfileImageAsync();
            var model = new EditProfileViewModel()
            {
                ProfileId = profile.ProfileId,
                ProfileImage = profile.Image
            };
            return model;
        }

        public async void UpdateProfile(EditProfileViewModel model)
        {
            var profile = await _profileRepositoy.GetProfileImageAsync();
            if (profile != null)
            {
                if (model.File != null)
                {
                    bool checkImage = model.File.IsImage();
                    if (checkImage)
                    {
                        ImageConvertor.RemoveImage(model.ProfileImage);
                        profile.Image = ImageConvertor.SaveImage(model.File);
                    }
                }
                _profileRepositoy.UpdateProfile(profile);
            }
        }
    }
}
