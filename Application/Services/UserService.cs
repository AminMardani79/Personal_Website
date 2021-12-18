using Application.Interface;
using Application.ViewModel.UserViewModel;
using Domain.Interface;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<IEnumerable<UserViewModel>> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsers();
            var model = new List<UserViewModel>();
            foreach (var user in users)
            {
                model.Add(new UserViewModel()
                {
                    UserId = user.Id,
                    FullName = user.UserName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber
                });
            }
            return model;
        }
        public async Task AddUserAsync(AddUserViewModel model)
        {
            var user = new IdentityUser()
            {
                UserName = model.UserName,
                Email = model.UserEmail,
                PhoneNumber = model.PhoneNumber,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            var result = await _userRepository.AddUserAsync(user,model.Password);
            if(result.Succeeded && model.HasAccess)
            {
                await _userRepository.AddClaimAsync(user, new Claim("AuthorizeValue", "Admin"));
            }
        }
        public async Task<bool> EditUserAsync(EditUserViewModel model)
        {
            bool EditResult;
            var user = await _userRepository.GetUserById(model.Id);
            var claims = await _userRepository.GetClaimsAsync(user);
            var authorizeClaim = _userRepository.GetClaim(claims.ToList());
            user.PhoneNumber = model.PhoneNumber;
            user.UserName = model.UserName;
            user.Email = model.UserEmail;
            var result = await _userRepository.EditUserAsync(user);
            if (!String.IsNullOrEmpty(model.NewPassword))
            {
                var resetPass = await _userRepository.ResetPasswordAsync(user, model.NewPassword);
                EditResult = true ? (result.Succeeded && resetPass.Succeeded) : false;
            }
            else
            {
                EditResult = true ? result.Succeeded : false;
            }
            if(model.HasAccess != authorizeClaim)
            {
                if (model.HasAccess)
                {
                    await _userRepository.AddClaimAsync(user, new Claim("AuthorizeValue", "Admin"));
                }
                else
                {
                    await _userRepository.RemoveClaimAsync(user, new Claim("AuthorizeValue", "Admin"));
                }
            }
            return EditResult;
        }
        public async Task<EditUserViewModel> GetUserAsync(string id)
        {
            var user = await _userRepository.GetUserById(id);
            var claims = await _userRepository.GetClaimsAsync(user);
            var authorizeClaim = _userRepository.GetClaim(claims.ToList());
            EditUserViewModel model = new()
            {
                Id = id,
                UserEmail = user.Email,
                PhoneNumber = user.PhoneNumber,
                UserName = user.UserName,
                LastPassword = user.PasswordHash,
                HasAccess = authorizeClaim
            };
            return model;
        }
        public async Task<bool> RemoveUserAsync(string id)
        {
            bool finalResult = false;
            var user = await _userRepository.GetUserById(id);
            if(user is not null)
            {
                var claims = await _userRepository.GetClaimsAsync(user);
                var claimRes = await _userRepository.RemoveClaimsAsync(user, claims);
                var userRes = await _userRepository.RemoveUserAsync(user);
                finalResult = true ? (claimRes.Succeeded && userRes.Succeeded) : false;
            }
            return finalResult;
        }
    }
}
