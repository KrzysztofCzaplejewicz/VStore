using Microsoft.EntityFrameworkCore;
using VStore.Models;

namespace VStore.Persistance
{
    public class StoreDbContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options) { }
    }
}
