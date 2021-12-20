using Application.Interface;
using Application.ViewModel.UserViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace PersonalWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = "Authorize")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        [Route("/Admin/Users")]
        public async Task<IActionResult> Index()
        {
            var users = await _userService.GetAllUsers();
            return View(users);
        }

        [HttpGet]
        [Route("/Admin/Users/Create")]
        public IActionResult CreateUser() => View();

        [HttpPost]
        [Route("/Admin/Users/Create")]
        public async Task<IActionResult> CreateUser(AddUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _userService.AddUserAsync(model);
                return RedirectToAction(nameof(Index),"User");
            }
            else
            {
                ModelState.AddModelError(string.Empty,"افزودن کاربر با مشکل مواجه شد");
                return View(model);
            }
        }
        [HttpGet]
        [Route("/Admin/Users/Edit/{id}")]
        public async Task<IActionResult> EditUser(string id)
        {
            var user = await _userService.GetUserAsync(id);
            return View(user);
        }

        [HttpPost]
        [Route("/Admin/Users/Edit/{id}")]
        public async Task<IActionResult> EditUser(EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.EditUserAsync(model);
                if (result)
                {
                    return RedirectToAction(nameof(Index), "User");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "ویرایش کاربر به طور کامل انجام نشد");
                    return View(model);
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "ویرایش کاربر با مشکل مواجه شد");
                return View(model);
            }
        }
        [HttpGet]
        [Route("/Admin/Users/Remove/{id}")]
        public async Task RemoveUser(string id)
        {
            await _userService.RemoveUserAsync(id);
        }
    }
}