using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IContactMessageRepository
    {
        Task<IEnumerable<ContactMessage>> GetMessagesList(string search,int skip,int take);
        Task<ContactMessage> GetMessageById(int messageId);
        void CreateMessage(ContactMessage message);
        void DeleteMessage(ContactMessage message);
        void Save();
    }
}