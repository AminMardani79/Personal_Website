using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IMessagesCountService
    {
        Task AttachMessagesCount();
        Task ReadMessages();
        Task<int> GetMessagesCount();
    }
}
