using CasaCodigo.Data.Mapping;
using CasaCodigo.Entities;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;

namespace CasaCodigo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);             
            modelBuilder.Ignore<Notification>();            
            modelBuilder.ApplyConfiguration(new AuthorMapping());
        }
            public DbSet<Author> Authors { get; private set; }
    }
}