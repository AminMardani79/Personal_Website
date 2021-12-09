using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface ICategoryProjectRepository
    {
        void CreateCPModels(List<CategoryProject> model);
        Task<IEnumerable<int>> GetSelectedCategoryIds(int projectId);
        Task<IEnumerable<CategoryProject>> GetCategoryProjectsById(int projectId);
        void RemoveAll(IEnumerable<CategoryProject> cpModel);
        void Save();
    }
}
