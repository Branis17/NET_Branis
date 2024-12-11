using Microsoft.EntityFrameworkCore;
using mvcTemplate.Models;

namespace mvcTemplate.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Teacher> Teachers { get; set; }
    }
}
