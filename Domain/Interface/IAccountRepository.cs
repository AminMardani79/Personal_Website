using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IAccountRepository
    {
        Task<SignInResult> SignInAsync(IdentityUser user, string password, bool isPersistent, bool lockOutOnFailure);
    }
}
