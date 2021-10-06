using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IContactDetailRepository
    {
        Task<ContactDetail> GetContactDetail();
        void UpdateContactDetail(ContactDetail detail);
        void Save();
    }
}