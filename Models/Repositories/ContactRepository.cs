﻿using PhoneManager.Models.Entities;
using PhoneManager.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace PhoneManager.Models.Repositories
{
    public class ContactRepository : BaseRepository, IContactRepository
    {
        public ContactRepository(AppDBContext context) : base(context)
        {
        }

        public async Task<List<Contact>> GetAllAsync()
        {
            return await context.Contacts.ToListAsync();
        }

        public async Task<Contact> GetAsync(Guid id)
        {
            return await context.Contacts.FirstOrDefaultAsync(i => i.Id == id);
        }
    }
}
