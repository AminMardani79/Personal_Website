using Application.ViewModel.DoWorkViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IDoWorkService
    {
        Tuple<List<DoWorkViewModel>, int, int> GetDoWorksList(string search, int take, int pageNumber = 1);
        Task<EditDoWorkViewModel> GetDoWorkById(int doWorkId);
        void CreateDoWork(CreateDoWorkViewModel doWork);
        void EditDoWork(EditDoWorkViewModel doWork);
        void DeleteDoWork(int doWorkId);
    }
}