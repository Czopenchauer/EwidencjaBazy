using Ewidencja.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Ewidencja.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public static readonly LoggerFactory LoggerFactory = new LoggerFactory(new[] {
            new Microsoft.Extensions.Logging.Debug.DebugLoggerProvider()
        });

        public DbSet<PESEL> PESELs { get; set; }

        public DbSet<Zameldowanie> Zameldowanies { get; set; }

        public DbSet<Wyjazd> Wyjazdies { get; set; }

        public DbSet<Edycja> Edycjas { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Wniosek> Wnioski { get; set; }

        public DbSet<Formularz> Formularze { get; set; }

        public DbSet<Typ> Typ { get; set; }

        public DbSet<Status> Status { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLoggerFactory(LoggerFactory);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            #region Table setup
            modelBuilder.Entity<PESEL>()
                .ToTable("PESEL");

            modelBuilder.Entity<Zameldowanie>()
                .ToTable("Zameldowanie");

            modelBuilder.Entity<Wyjazd>()
                .ToTable("Wyjazd");

            modelBuilder.Entity<Edycja>()
                .ToTable("Edycja");

            modelBuilder.Entity<User>()
                .ToTable("Uzytkownik");

            modelBuilder.Entity<Wniosek>()
                .ToTable("Wnioski");

            modelBuilder.Entity<Formularz>()
                .ToTable("Formularz");

            modelBuilder.Entity<Typ>()
                .ToTable("Typ");

            modelBuilder.Entity<Status>()
                .ToTable("Status");
            #endregion


        }
    }
}
