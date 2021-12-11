using Application.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace PersonalWebsite.Components
{
    public class CategoryViewComponent:ViewComponent
    {
        private readonly IProjectCategoryService _projectCategoryService;

        public CategoryViewComponent(IProjectCategoryService projectCategoryService)
        {
            _projectCategoryService = projectCategoryService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("/Views/Shared/_Category.cshtml",await _projectCategoryService.ShowCategories());
        }
    }
}
