using Application.Interface;
using Application.Others;
using Application.ViewModel.ContactViewModel;
using Domain.Interface;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ContactMessageService : IContactMessageService
    {
        private readonly IContactMessageRepository _contactMessageRepository;
        public ContactMessageService(IContactMessageRepository contactMessageRepository)
        {
            _contactMessageRepository = contactMessageRepository;
        }
        public void CreateMessage(CreateContactMessageViewModel message)
        {
            ContactMessage model = new ContactMessage();
            model.MessageDescription = message.MessageDescription;
            model.MessageTitle = message.MessageTitle;
            model.UserEmail = message.UserEmail;
            model.UserName = message.UserName;
            model.UserNumber = message.UserNumber;
            _contactMessageRepository.CreateMessage(model);
        }

        public void DeleteMessage(int messageId)
        {
            var message = _contactMessageRepository.GetMessageById(messageId).Result;
            _contactMessageRepository.DeleteMessage(message);
        }

        public async Task<EditContactMessageViewModel> GetMessageById(int messageId)
        {
            var message = await _contactMessageRepository.GetMessageById(messageId);
            EditContactMessageViewModel model = new EditContactMessageViewModel();
            model.MessageDescription = message.MessageDescription;
            model.MessageTitle = message.MessageTitle;
            model.UserEmail = message.UserEmail;
            model.UserName = message.UserName;
            model.UserNumber = message.UserNumber;
            model.MessageId = message.MessageId;
            return model;
        }

        public Tuple<List<ContactMessageViewModel>, int, int> GetMessagesList(string search,int take, int pageNumber = 1)
        {
            int skip = (pageNumber - 1) * take;
            var messagesList = _contactMessageRepository.GetMessagesList(search,skip,take).Result;
            int pagesCount = PagesCount.PageCount(messagesList.Count(), take);
            List<ContactMessageViewModel> models = new List<ContactMessageViewModel>();
            foreach (var message in messagesList)
            {
                models.Add(new ContactMessageViewModel()
                { 
                    MessageTitle = message.MessageTitle,
                    UserEmail = message.UserEmail,
                    UserName = message.UserName,
                    UserNumber = message.UserNumber,
                    MessageId = message.MessageId,
                    MessageDesc = message.MessageDescription
                });
            }
            return Tuple.Create(models,pagesCount,pageNumber);
        }
    }
}