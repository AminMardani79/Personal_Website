using Application.Interface;
using Application.ViewModel.ContactViewModel;
using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ContactDetailService : IContactDetailService
    {
        private readonly IContactDetailRepository _contactDetailRepository;
        public ContactDetailService(IContactDetailRepository contactDetailRepository)
        {
            _contactDetailRepository = contactDetailRepository;
        }
        public async Task<EditContactDetailViewModel> GetContactDetail()
        {
            var detail = await _contactDetailRepository.GetContactDetail();
            EditContactDetailViewModel model = new EditContactDetailViewModel();
            model.ContactDescription = detail.ContactDescription;
            model.ContactEmail = detail.ContactEmail;
            model.ContactId = detail.ContactId;
            model.ContactNumber = detail.ContactNumber;
            model.Instagram = detail.Instagram;
            model.LinkdIn = detail.LinkdIn;
            model.Telegram = detail.Telegram;
            return model;
        }

        public void UpdateContactDetail(EditContactDetailViewModel detail)
        {
            var model = _contactDetailRepository.GetContactDetail().Result;
            model.ContactDescription = detail.ContactDescription;
            model.ContactEmail = detail.ContactEmail;
            model.ContactNumber = detail.ContactNumber;
            model.Instagram = detail.Instagram;
            model.LinkdIn = detail.LinkdIn;
            model.Telegram = detail.Telegram;
            _contactDetailRepository.UpdateContactDetail(model);
        }
    }
}
