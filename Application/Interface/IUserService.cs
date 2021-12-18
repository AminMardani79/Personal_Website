using Application.ViewModel.UserViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IUserService
    {
        Task<IEnumerable<UserViewModel>> GetAllUsers();
        Task AddUserAsync(AddUserViewModel model);
        Task<bool> EditUserAsync(EditUserViewModel model);
        Task<EditUserViewModel> GetUserAsync(string id);
        Task<bool> RemoveUserAsync(string id);
    }
}