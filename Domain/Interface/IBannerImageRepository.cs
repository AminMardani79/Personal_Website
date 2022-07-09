using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IBannerImageRepository
    {
        void UpdateBanner(BannerImage image);
        Task<BannerImage> GetBannerImageAsync();
        void Save();
    }
}
