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
    public class MessagesCountRepository : IMessagesCountRepository
    {
        private readonly ApplicationDbContext _context;

        public MessagesCountRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void AttachMessagesCount(MessagesCount model)
        {
            _context.Attach(model);
            Save();
        }

        public async Task<MessagesCount> GetMessagesCount()
        {
            return await _context.MessagesCount.FirstOrDefaultAsync();
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
