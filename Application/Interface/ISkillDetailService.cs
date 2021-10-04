using Application.ViewModel.SkillViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface ISkillDetailService
    {
        Tuple<List<SkillDetailViewModel>, int, int> GetSkillDetailsList(string search, int take, int pageNumber = 1);
        Task<EditSkillDetailViewModel> GetSkillDetailById(int skillId);
        void CreateSkillDetail(CreateSkillDetailViewModel skill);
        void EditSkillDetail(EditSkillDetailViewModel skill);
        void DeleteSkillDetail(int skillId);
    }
}