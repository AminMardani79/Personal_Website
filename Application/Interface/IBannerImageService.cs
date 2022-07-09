using Application.ViewModel.BannerViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IBannerImageService
    {
        Task UpdateBanner(EditBannerImageViewModel model);
        Task<EditBannerImageViewModel> GetBannerAsync();
    }
}
