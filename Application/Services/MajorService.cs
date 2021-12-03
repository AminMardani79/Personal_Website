using Application.Interface;
using Application.Others;
using Application.ViewModel.MajorViewModel;
using Domain.Interface;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class MajorService : IMajorService
    {
        private readonly IMajorRepository _majorRepository;
        public MajorService(IMajorRepository majorRepository)
        {
            _majorRepository = majorRepository;
        }
        public void CreateMajor(CreateMajorViewModel major)
        {
            Major model = new Major();
            model.MajorEnd = major.MajorEnd;
            model.MajorStart = major.MajorStart;
            model.MajorSubTitle = major.MajorSubTitle;
            model.MajorTitle = major.MajorTitle;
            _majorRepository.CreateMajor(model);
        }

        public void DeleteMajor(int majorId)
        {
            var major = _majorRepository.GetMajorById(majorId).Result;
            _majorRepository.DeleteMajor(major);
        }

        public void EditMajor(EditMajorViewModel major)
        {
            var model = _majorRepository.GetMajorById(major.MajorId).Result;
            model.MajorEnd = major.MajorEnd;
            model.MajorStart = major.MajorStart;
            model.MajorSubTitle = major.MajorSubTitle;
            model.MajorTitle = major.MajorTitle;
            model.MajorId = major.MajorId;
            _majorRepository.UpdateMajor(model);
        }

        public async Task<EditMajorViewModel> GetMajorById(int majorId)
        {
            var major = await _majorRepository.GetMajorById(majorId);
            EditMajorViewModel model = new EditMajorViewModel();
            model.MajorId = major.MajorId;
            model.MajorEnd = major.MajorEnd;
            model.MajorStart = major.MajorStart;
            model.MajorSubTitle = major.MajorSubTitle;
            model.MajorTitle = major.MajorTitle;
            return model;
        }

        public Tuple<List<MajorViewModel>, int, int> GetMajorsList(string search, int take, int pageNumber = 1)
        {
            int skip = (pageNumber - 1) * take;
            var majorList = _majorRepository.GetMajoresList(search, skip, take).Result;
            int pagesCount = PagesCount.PageCount(majorList.Count(), take);
            List<MajorViewModel> models = new List<MajorViewModel>();
            foreach (var major in majorList)
            {
                models.Add(new MajorViewModel()
                {
                    MajorId = major.MajorId,
                    MajorEnd = major.MajorEnd,
                    MajorStart = major.MajorStart,
                    MajorSubTitle = major.MajorSubTitle,
                    MajorTitle = major.MajorTitle,
                });
            }
            return Tuple.Create(models, pagesCount, pageNumber);
        }
        public async Task<IEnumerable<MajorViewModel>> ShowMajors()
        {
            var majors = await _majorRepository.ShowMajors();
            var vModel = new List<MajorViewModel>();
            foreach (var major in majors)
            {
                vModel.Add(new MajorViewModel()
                {
                    MajorId = major.MajorId,
                    MajorTitle = major.MajorTitle,
                    MajorSubTitle = major.MajorSubTitle,
                    MajorStart = major.MajorStart,
                    MajorEnd = major.MajorEnd
                });
            }
            return vModel;
        }
    }
}
