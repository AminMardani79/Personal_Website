using Application.Interface;
using Application.Others;
using Application.ViewModel.DoWorkViewModel;
using Domain.Interface;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class DoWorkService : IDoWorkService
    {
        private readonly IDoWorkRepository _doWorkRepository;
        public DoWorkService(IDoWorkRepository doWorkRepository)
        {
            _doWorkRepository = doWorkRepository;
        }
        public void CreateDoWork(CreateDoWorkViewModel doWork)
        {
            DoWork model = new DoWork();
            model.DoWorkDesc = doWork.DoWorkDesc;
            model.DoWorkTitle = doWork.DoWorkTitle;
            model.DoWorkIcon = doWork.DoWorkIcon;
            _doWorkRepository.CreateDoWork(model);
        }

        public void DeleteDoWork(int doWorkId)
        {
            var doWork = _doWorkRepository.GetDoWorkById(doWorkId).Result;
            _doWorkRepository.DeleteDoWork(doWork);
        }

        public void EditDoWork(EditDoWorkViewModel doWork)
        {
            var model = _doWorkRepository.GetDoWorkById(doWork.DoWorkId).Result;
            model.DoWorkDesc = doWork.DoWorkDesc;
            model.DoWorkTitle = doWork.DoWorkTitle;
            model.DoWorkIcon = doWork.DoWorkIcon;
            _doWorkRepository.UpdateDoWork(model);
        }

        public async Task<EditDoWorkViewModel> GetDoWorkById(int doWorkId)
        {
            var doWork = await _doWorkRepository.GetDoWorkById(doWorkId);
            EditDoWorkViewModel model = new EditDoWorkViewModel();
            model.DoWorkTitle = doWork.DoWorkTitle;
            model.DoWorkDesc = doWork.DoWorkDesc;
            model.DoWorkIcon = doWork.DoWorkIcon;
            model.DoWorkId = doWorkId;
            return model;
        }

        public Tuple<List<DoWorkViewModel>, int, int> GetDoWorksList(string search, int take, int pageNumber = 1)
        {
            int skip = (pageNumber - 1) * take;
            var doWorkList = _doWorkRepository.GetDoWorksList(search, skip, take).Result;
            var doWorksCount = _doWorkRepository.GetDoWorksCount().Result;
            int pagesCount = PagesCount.PageCount(doWorksCount, take);
            List<DoWorkViewModel> models = new List<DoWorkViewModel>();
            foreach (var doWork in doWorkList)
            {
                models.Add(new DoWorkViewModel()
                {
                    DoWorkId = doWork.DoWorkId,
                    DoWorkTitle = doWork.DoWorkTitle,
                    DoWorkIcon = doWork.DoWorkIcon
                });
            }
            return Tuple.Create(models, pagesCount, pageNumber);
        }

        public async Task<IEnumerable<DoWorkViewModel>> ShowDoWorks()
        {
            var doWorks = await _doWorkRepository.ShowDoWorks();
            var list = new List<DoWorkViewModel>();
            foreach (var item in doWorks)
            {
                list.Add(new()
                {
                    DoWorkId = item.DoWorkId,
                    DoWorkIcon = item.DoWorkIcon,
                    DoWorkTitle = item.DoWorkTitle,
                    DoWorkDesc = item.DoWorkDesc
                });
            }
            return list;
        }
    }
}
