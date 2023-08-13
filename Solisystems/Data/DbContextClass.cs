
using Microsoft.EntityFrameworkCore;
using Solisystems.Domain.Entities;

namespace Solisystems.Data
{
    public class DbContextClass : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductEntity> Products { get; set; }

        public DbContextClass(DbContextOptions<DbContextClass> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasIndex(c => c.CategoryCode)
                .IsUnique();

            modelBuilder.Entity<Category>()
                .Property(c => c.CreationDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<ProductEntity>()
                .HasIndex(c => c.ProductCode)
                .IsUnique();

            modelBuilder.Entity<ProductEntity>()
                .Property(c => c.CreationDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");


            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
        }
    }

}
