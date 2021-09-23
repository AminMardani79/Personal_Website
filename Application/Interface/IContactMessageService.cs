
using Application.ViewModel.ContactViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IContactMessageService
    {
        Tuple<List<ContactMessageViewModel>, int, int> GetMessagesList(string search, int take, int pageNumber = 1);
        Task<EditContactMessageViewModel> GetMessageById(int messageId);
        void CreateMessage(CreateContactMessageViewModel message);
        void DeleteMessage(int messageId);
    }
}