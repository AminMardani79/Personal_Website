using Application.Interface;
using Application.ViewModel.LoginViewModel;
using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IUserRepository _userRepository;

        public AccountService(IAccountRepository accountRepository,IUserRepository userRepository)
        {
            _accountRepository = accountRepository;
            _userRepository = userRepository;
        }
        public async Task<bool> SignInUser(LoginViewModel model)
        {
            bool finalResult = false;
            var user = await _userRepository.GetUserByEmail(model.Email);
            bool checkPass = await _userRepository.CheckPasswordAsync(user, model.Password);
            if (checkPass)
            {
                var result = await _accountRepository.SignInAsync(user, model.Password, model.RememberMe, false);
                finalResult = true ? (result.Succeeded) : false;
            }
            return finalResult;
        }
    }
}