using Microsoft.EntityFrameworkCore;

namespace Login.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<UserSavedInformation> UserSavedInformation { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=MyDatabase.db");
        }
    }
}
