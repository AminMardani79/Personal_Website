
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IUserRepository
    {
        Task<IEnumerable<IdentityUser>> GetAllUsers();
        Task<IdentityUser> GetUserById(string id);
        Task<IdentityResult> AddUserAsync(IdentityUser user,string password);
        Task<IdentityResult> EditUserAsync(IdentityUser user);
        Task<IdentityResult> RemoveUserAsync(IdentityUser user);
        Task<IdentityResult> ResetPasswordAsync(IdentityUser user,string newPassword);

        #region Claim

        Task AddClaimAsync(IdentityUser user, Claim claim);
        Task<IdentityResult> RemoveClaimsAsync(IdentityUser user, IEnumerable<Claim> claims);
        Task RemoveClaimAsync(IdentityUser user, Claim claim);
        Task<IEnumerable<Claim>> GetClaimsAsync(IdentityUser user);
        bool GetClaim(List<Claim> claims);

        #endregion

    }
}