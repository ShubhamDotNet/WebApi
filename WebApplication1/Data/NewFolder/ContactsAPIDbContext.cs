using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data.NewFolder
{
    public class ContactsAPIDbContext: DbContext
    {
        public ContactsAPIDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Contact> Contacts { get; set; }
    }
}
