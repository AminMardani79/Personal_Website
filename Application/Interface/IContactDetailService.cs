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
        Task<EditContactDetailViewModel> GetContactDetail();
        void UpdateContactDetail(EditContactDetailViewModel detail);
    }
}