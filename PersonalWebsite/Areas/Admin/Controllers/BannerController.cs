using Application.Interface;
using Application.ViewModel.BannerViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace PersonalWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = "Authorize")]
    public class BannerController : Controller
    {
        private readonly IBannerImageService _bannerImageService;
        public BannerController(IBannerImageService bannerImageService)
        {
            _bannerImageService = bannerImageService;
        }
        [HttpGet]
        [Route("/Admin/EditBanner")]
        public IActionResult EditBanner()
        {
            var banner = _bannerImageService.GetBannerAsync().Result;
            return View(banner);
        }
        [HttpPost]
        [Route("/Admin/EditBanner")]
        public async Task<IActionResult> EditProfile(EditBannerImageViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await _bannerImageService.UpdateBanner(model);
            return RedirectToAction("EditBanner", "Banner");
        }
    }
}
