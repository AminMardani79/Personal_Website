using Application.ViewModel.ContactViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IContactDetailService
    {
        Task<EditContactDetailViewModel> GetContactDetailById(int detailId);
        void UpdateContactDetail(EditContactDetailViewModel detail);
    }
}
