using Application.Interface;
using Application.ViewModel.LoginViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace PersonalWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpGet]
        [Route("/Admin/Account/Login")]
        public IActionResult Login() => View();
        [HttpPost]
        [Route("/Admin/Account/Login")]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var signInResult = await _accountService.SignInUser(model);
                if (signInResult)
                {
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction(nameof(DashboardController.Index), "Dashboard");
                    }
                }
                else
                {
                    ModelState.AddModelError("Password", "کاربری با مشخضات وارد شده یافت نشد");
                }
            }
            else
            {
                ModelState.AddModelError("Password", "ورود با مشکل مواجه شد !!");
            }
            return View();
        }
        [HttpGet]
        [Route("/Logout")]
        public async Task<IActionResult> SignOutAsync()
        {
            await _accountService.SignOutAsync();
            return Redirect("/");
        }
    }
}