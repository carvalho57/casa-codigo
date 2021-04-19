using System.Reflection;
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
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());            
        }
        public DbSet<Author> Authors { get; private set; }
        public DbSet<Category> Categories { get; private set; }
        public DbSet<Book> Books {get;private set;}
        public DbSet<State> States { get; private set; }
        public DbSet<Country> Countries { get; private set; }
    }
}
