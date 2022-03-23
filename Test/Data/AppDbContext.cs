using Microsoft.EntityFrameworkCore;

namespace Test.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Pipe> Pipes { get; set; }
        public DbSet<Package> Packages { get; set; }

        protected override void OnConfiguring(
           DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(
                "Data Source=db.db");
            //optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
