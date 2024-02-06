using Microsoft.EntityFrameworkCore;

namespace testTask1.Models
{
    public class Context: DbContext
    {
        public DbSet<Link> Links { get; set; }
        public Context() {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=testtask1;Username=postgres;Password=0000");
        }
    }
}
