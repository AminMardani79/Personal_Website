using Domain.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class UserRepository:IUserRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public UserRepository(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public async Task<IdentityResult> AddUserAsync(IdentityUser user,string password)
        {
           return await _userManager.CreateAsync(user,password);
        }

        public async Task<IdentityResult> EditUserAsync(IdentityUser user)
        {
            return await _userManager.UpdateAsync(user);
        }
        public async Task<IdentityResult> RemoveUserAsync(IdentityUser user)
        {
            return await _userManager.DeleteAsync(user);
        }
        public async Task<IdentityResult> ResetPasswordAsync(IdentityUser user, string newPassword)
        {
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            return await _userManager.ResetPasswordAsync(user,token,newPassword);
        }
        public async Task<IEnumerable<IdentityUser>> GetAllUsers()
        {
            return await _userManager.Users.ToListAsync();
        }

        public async Task<IdentityUser> GetUserById(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }



        #region Claims


        public async Task AddClaimAsync(IdentityUser user, Claim claim)
        {
            await _userManager.AddClaimAsync(user, claim);
        }
        public async Task<IEnumerable<Claim>> GetClaimsAsync(IdentityUser user)
        {
            return await _userManager.GetClaimsAsync(user);
        }
        public bool GetClaim(List<Claim> claims)
        {
            return claims.Any(c => c.Type == "AuthorizeValue");
        }
        public async Task RemoveClaimAsync(IdentityUser user, Claim claim)
        {
            await _userManager.RemoveClaimAsync(user, claim);
        }
        public async Task<IdentityResult> RemoveClaimsAsync(IdentityUser user, IEnumerable<Claim> claims)
        {
            return await _userManager.RemoveClaimsAsync(user, claims);
        }

        #endregion
    }
}