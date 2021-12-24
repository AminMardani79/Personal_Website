using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IMessagesCountRepository
    {
        Task<MessagesCount> GetMessagesCount();
        void AttachMessagesCount(MessagesCount model);
        void Save();
    }
}
