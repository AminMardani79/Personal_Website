using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = "Authorize")]
    public class DashboardController : Controller
    {
        [Route("/Admin/Dashboard")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
