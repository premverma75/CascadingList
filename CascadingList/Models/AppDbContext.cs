using Microsoft.EntityFrameworkCore;

namespace CascadingList.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Register> Registers { get; set; }
        public DbSet<Login> Logins { get; set; }
    }
}
