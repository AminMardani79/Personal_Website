using Application.ViewModel.LoginViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IAccountService
    {
        Task<bool> SignInUser(LoginViewModel model);
    }
}
