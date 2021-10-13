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
            if(doWork.DoWorkImage != null)
            {
                bool check = doWork.DoWorkImage.IsImage();
                if (check)
                {
                    model.DoWorkImage = ImageConvertor.SaveImage(doWork.DoWorkImage);
                }
                else
                {
                    model.DoWorkImage = "default.png";
                }
            }
            else
            {
                model.DoWorkImage = "default.png";
            }
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
            if(doWork.ImageFile != null)
            {
                bool checkImage = doWork.ImageFile.IsImage();
                if (checkImage)
                {
                    ImageConvertor.RemoveImage(doWork.DoWorkImage);
                    model.DoWorkImage = ImageConvertor.SaveImage(doWork.ImageFile);
                }
            }
            _doWorkRepository.UpdateDoWork(model);
        }

        public async Task<EditDoWorkViewModel> GetDoWorkById(int doWorkId)
        {
            var doWork = await _doWorkRepository.GetDoWorkById(doWorkId);
            EditDoWorkViewModel model = new EditDoWorkViewModel();
            model.DoWorkTitle = doWork.DoWorkTitle;
            model.DoWorkDesc = doWork.DoWorkDesc;
            model.DoWorkImage = doWork.DoWorkImage;
            model.DoWorkId = doWorkId;
            return model;
        }

        public Tuple<List<DoWorkViewModel>, int, int> GetDoWorksList(string search, int take, int pageNumber = 1)
        {
            int skip = (pageNumber - 1) * take;
            var doWorkList = _doWorkRepository.GetDoWorksList(search, skip, take).Result;
            int pagesCount = PagesCount.PageCount(doWorkList.Count(), take);
            List<DoWorkViewModel> models = new List<DoWorkViewModel>();
            foreach (var doWork in doWorkList)
            {
                models.Add(new DoWorkViewModel()
                {
                    DoWorkId = doWork.DoWorkId,
                    DoWorkTitle = doWork.DoWorkTitle,
                    DoWorkImage = doWork.DoWorkImage
                });
            }
            return Tuple.Create(models, pagesCount, pageNumber);
        }
    }
}
