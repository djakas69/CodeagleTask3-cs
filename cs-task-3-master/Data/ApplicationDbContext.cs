using Csharp_Task_3.Models;
using Microsoft.EntityFrameworkCore;

namespace Csharp_Task_3.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<LocalUser> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LocalUser>().HasData(                
                new LocalUser()
                {
                    Id = 1,
                    Name = "darko",
                    UserName="darko",
                    Password="12345",
                    Role="admin"
                });
        }
    }
}
