using Microsoft.EntityFrameworkCore;
using PruebaTecnicaEdison.Domain.Entities;

namespace PruebaTecnicaEdison.DataAccess.Context
{
    public partial class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Person> Person { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Person>().ToTable("People");
            modelBuilder.Entity<Person>(entity => 
            {
                entity.HasKey(pro => pro.PersonaId);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
