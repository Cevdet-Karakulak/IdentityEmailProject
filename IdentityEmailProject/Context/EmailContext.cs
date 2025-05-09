using IdentityEmailProject.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityEmailProject.Context
{
    public class EmailContext : IdentityDbContext<AppUser>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=FLOPPA\\SS17; initial Catalog=EmailChatProjectDb;integrated Security=true;trust server certificate=true");
        }
        public DbSet<Message> Messages { get; set; }
    }
}
