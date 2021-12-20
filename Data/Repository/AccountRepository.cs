using Domain.Interface;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        public AccountRepository(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }
        public async Task<SignInResult> SignInAsync(IdentityUser user,string password,bool isPersistent,bool lockOutOnFailure)
        {
            return await _signInManager.PasswordSignInAsync(user, password, isPersistent, lockOutOnFailure);
        }
    }
}
