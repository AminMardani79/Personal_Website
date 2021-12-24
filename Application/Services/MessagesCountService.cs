using Application.Interface;
using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class MessagesCountService : IMessagesCountService
    {
        private readonly IMessagesCountRepository _messagesCountRepository;

        public MessagesCountService(IMessagesCountRepository messagesCountRepository)
        {
            _messagesCountRepository = messagesCountRepository;
        }
        public async Task AttachMessagesCount()
        {
            var model = await _messagesCountRepository.GetMessagesCount();
            model.NewMessagesNumber++;
            _messagesCountRepository.AttachMessagesCount(model);
        }

        public async Task<int> GetMessagesCount()
        {
            var model = await _messagesCountRepository.GetMessagesCount();
            return model.NewMessagesNumber;
        }
        public async Task ReadMessages()
        {
            var model = await _messagesCountRepository.GetMessagesCount();
            model.NewMessagesNumber = 0;
            _messagesCountRepository.AttachMessagesCount(model);
        }
    }
}
