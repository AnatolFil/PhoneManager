using Microsoft.EntityFrameworkCore;
using PhoneManager.Models.Entities;
using System.Net;

namespace PhoneManager.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        public DbSet<Call> Calls { get; set; }
        public DbSet<Conference> Conferences { get; set; }
        public DbSet<ConferenceContact> ConferenceContacts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
    }
}
