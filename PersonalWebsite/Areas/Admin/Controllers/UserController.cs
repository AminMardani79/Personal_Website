﻿using Microsoft.AspNetCore.Mvc;

namespace PersonalWebsite.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
