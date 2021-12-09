using Application.Interface;
using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CategoryProjectService:ICategoryProjectService
    {
        private readonly ICategoryProjectRepository _categoryProjectRepository;

        public CategoryProjectService(ICategoryProjectRepository categoryProjectRepository)
        {
            _categoryProjectRepository = categoryProjectRepository;
        }
        public async Task<IEnumerable<int>> GetSelectedCategoryIds(int projectId)
        {
            return await _categoryProjectRepository.GetSelectedCategoryIds(projectId);
        }
    }
}
