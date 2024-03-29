﻿using Data.ApplicationContext;
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
    public class ContactMessageRepository : IContactMessageRepository
    {
        private readonly ApplicationDbContext _context;
        public ContactMessageRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void CreateMessage(ContactMessage message)
        {
            _context.Add(message);
            Save();
        }

        public void DeleteMessage(ContactMessage message)
        {
            _context.Remove(message);
            Save();
        }

        public async Task<ContactMessage> GetMessageById(int messageId)
        {
            return await _context.ContactMessages.SingleOrDefaultAsync(c=> c.MessageId == messageId);
        }

        public async Task<IEnumerable<ContactMessage>> GetMessagesList(string search, int skip, int take)
        {
            return await _context.ContactMessages.Where(c=> EF.Functions.Like(c.UserName,$"%{search}%")).OrderByDescending(c=> c.MessageId).Skip(skip).Take(take).ToListAsync();
        }
        public void AttachMessage(ContactMessage message)
        {
            _context.Attach(message);
            Save();
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        public async Task<IEnumerable<ContactMessage>> ShowActiveMessages()
        {
            return await _context.ContactMessages.Where(m => m.IsShowing).OrderByDescending(m => m.MessageId).ToListAsync();
        }
        public async Task<int> GetMessagesCount()
        {
            return await _context.ContactMessages.CountAsync();
        }
    }
}