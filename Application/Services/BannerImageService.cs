using Application.Interface;
using Application.Others;
using Application.ViewModel.BannerViewModel;
using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class BannerImageService : IBannerImageService
    {
        private readonly IBannerImageRepository _bannerImageRepository;
        public BannerImageService(IBannerImageRepository bannerImageRepository)
        {
            _bannerImageRepository = bannerImageRepository;
        }

        public async Task<EditBannerImageViewModel> GetBannerAsync()
        {
            var banner = await _bannerImageRepository.GetBannerImageAsync();
            var model = new EditBannerImageViewModel()
            {
                BannerImage = banner.Image,
                BannerId = banner.BannerId,
                BannerTitle = banner.BannerTitle,
                FullName = banner.FullName,
                Description = banner.Description,
                ResumeLink = banner.ResumeLink
            };
            return model;
        }

        public async Task UpdateBanner(EditBannerImageViewModel model)
        {
            var banner = await _bannerImageRepository.GetBannerImageAsync();
            bool checkImage = model.File.IsImage();
            if (banner != null)
            {
                banner.BannerTitle = model.BannerTitle;
                banner.FullName = model.FullName;
                banner.Description = model.Description;
                banner.ResumeLink = model.ResumeLink;
                if (model.File != null && checkImage)
                {
                    ImageConvertor.RemoveImage(model.BannerImage);
                    banner.Image = ImageConvertor.SaveImage(model.File);
                }
                _bannerImageRepository.UpdateBanner(banner);
            }
        }
    }
}
