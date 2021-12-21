using Application.Interface;
using Application.Others;
using Application.ViewModel.SkillViewModel;
using Domain.Interface;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class SkillDetailService : ISkillDetailService
    {
        private readonly ISkillDetailRepository _skillDetailRepository;
        public SkillDetailService(ISkillDetailRepository skillDetailRepository)
        {
            _skillDetailRepository = skillDetailRepository;
        }

        public void CreateSkillDetail(CreateSkillDetailViewModel skill)
        {
            SkillDetail model = new SkillDetail();
            model.SkillId = skill.SkillId;
            model.SkillPercent = skill.SkillPercent;
            model.SkillTitle = skill.SkillTitle;
            _skillDetailRepository.CreateSkillDetail(model);
        }

        public void DeleteSkillDetail(int skillDetailId)
        {
            var model = _skillDetailRepository.GetSkillDetailById(skillDetailId).Result;
            _skillDetailRepository.DeleteSkillDetail(model);
        }

        public void EditSkillDetail(EditSkillDetailViewModel skill)
        {
            var model = _skillDetailRepository.GetSkillDetailById(skill.SkillDetailId).Result;
            model.SkillId = skill.SkillId;
            model.SkillPercent = skill.SkillPercent;
            model.SkillTitle = skill.SkillTitle;
            _skillDetailRepository.UpdateSkillDetail(model);
        }

        public async Task<EditSkillDetailViewModel> GetSkillDetailById(int skillDetailId)
        {
            var skill = await _skillDetailRepository.GetSkillDetailById(skillDetailId);
            EditSkillDetailViewModel model = new EditSkillDetailViewModel();
            model.SkillId = skill.SkillId;
            model.SkillPercent = skill.SkillPercent;
            model.SkillDetailId = skill.SkillDetailId;
            model.SkillTitle = skill.SkillTitle;
            return model;
        }

        public Tuple<List<SkillDetailViewModel>, int, int> GetSkillDetailsList(string search, int take, int pageNumber = 1)
        {
            int skip = (pageNumber - 1) * take;
            var detailList = _skillDetailRepository.GetSkillDetailsList(search, skip, take).Result;
            var skillCounts = _skillDetailRepository.GetSkillsCount().Result;
            int pagesCount = PagesCount.PageCount(skillCounts, take);
            List<SkillDetailViewModel> models = new List<SkillDetailViewModel>();
            foreach (var detail in detailList)
            {
                models.Add(new SkillDetailViewModel()
                {
                    SkillDetailId = detail.SkillDetailId,
                    SkillId = detail.SkillId,
                    SkillTitle = detail.SkillTitle,
                    SkillPercent = detail.SkillPercent
                });
            }
            return Tuple.Create(models, pagesCount, pageNumber);
        }

        public async Task<IEnumerable<SkillDetailViewModel>> ShowSkillDetails()
        {
            var details = await _skillDetailRepository.ShowSkillDetails();
            var list = new List<SkillDetailViewModel>();
            foreach (var item in details)
            {
                list.Add(new()
                {
                    SkillDetailId = item.SkillDetailId,
                    SkillId = item.SkillId,
                    SkillTitle = item.SkillTitle,
                    SkillPercent = item.SkillPercent
                });
            }
            return list;
        }
    }
}