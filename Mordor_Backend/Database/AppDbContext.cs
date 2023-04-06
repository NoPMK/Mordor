using Microsoft.EntityFrameworkCore;

namespace Mordor_Backend.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Ork> Orks { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
    }
}
