using Application.ViewModel.MajorViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IMajorService
    {
        Tuple<List<MajorViewModel>, int, int> GetMajorsList(string search, int take, int pageNumber = 1);
        Task<EditMajorViewModel> GetMajorById(int majorId);
        void CreateMajor(CreateMajorViewModel major);
        void EditMajor(EditMajorViewModel major);
        void DeleteMajor(int majorId);
        Task<IEnumerable<MajorViewModel>> ShowMajors();
    }
}
