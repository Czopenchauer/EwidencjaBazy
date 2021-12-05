using Ewidencja.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Ewidencja
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public static readonly LoggerFactory LoggerFactory = new LoggerFactory(new[] {
            new Microsoft.Extensions.Logging.Debug.DebugLoggerProvider()
        });

        public DbSet<PESEL> PESELs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLoggerFactory(LoggerFactory);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PESEL>()
                .ToTable("PESEL");
        }
    }
}
