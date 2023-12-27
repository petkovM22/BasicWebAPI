using BasicWebApi.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BasicWebApi.DataAccess
{
    public class BasicWebApiDbContext : DbContext
    {
        public BasicWebApiDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Contact> Contacts { get; set; }

    }
}