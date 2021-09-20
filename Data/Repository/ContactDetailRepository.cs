using Data.ApplicationContext;
using Domain.Interface;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class ContactDetailRepository : IContactDetailRepository
    {
        private readonly ApplicationDbContext _context;
        public ContactDetailRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ContactDetail> GetContactDetailById(int detailId)
        {
            return await _context.ContactDetails.SingleOrDefaultAsync(c=> c.ContactId == detailId);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateContactDetail(ContactDetail detail)
        {
            _context.Update(detail);
            Save();
        }
    }
}
