using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IProfileImageRepository
    {
        void UpdateProfile(ProfileImage image);
        Task<ProfileImage> GetProfileImageAsync();
        void Save();
    }
}
