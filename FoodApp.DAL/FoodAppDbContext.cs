using FoodApp.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace FoodApp.DAL
{
    public class FoodAppDbContext : DbContext
    {
        public FoodAppDbContext(DbContextOptions<FoodAppDbContext> options)
            : base(options)
        {

        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<Order> Orders { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(c =>
            {
                c.Property(c => c.FirstName)
                 .IsRequired()
                 .HasMaxLength(50);

                c.Property(c => c.LastName)
                 .IsRequired()
                 .HasMaxLength(50);

                c.Property(c => c.FullName)
                .HasComputedColumnSql("[FirstName] + ' ' + [LastName] + ' '", stored: true);

                c.HasIndex(c => c.Email, "IX_UniqueEmail")
                .IsUnique();

                c.HasIndex(c => c.PhoneNumber, "IX_UniquePhoneNumber")
                .IsUnique();
            });


            modelBuilder.Entity<Menu>(m =>
            {
                m.Property(m => m.Title)
                .IsRequired()
                .HasMaxLength(50);
                
                m.Property(m => m.Price)
                .IsRequired()
                .HasPrecision(18, 2);

                m.Property(m => m.Picture)
                .IsRequired(false);
 
                m.Property(m => m.Description)
                .IsRequired()
                .HasMaxLength(100);

            });

            modelBuilder.Entity<Admin>(a =>
            {
                a.Property(a => a.UserName)
                .IsRequired()
                .HasMaxLength(50);
            });
                

            
            base.OnModelCreating(modelBuilder);
        }
    }
}
