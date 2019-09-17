using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TECHNICALTEST_AS_ME.Domains.Models;

namespace TECHNICALTEST_AS_ME.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.;Database=SNACKSTORE;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Category>().ToTable("categories");
            builder.Entity<Category>().HasKey(p => p.CategoryID);
            builder.Entity<Category>().Property(p => p.CategoryID).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Category>().Property(p => p.Name).IsRequired().HasMaxLength(30);

            builder.Entity<Category>()
                .HasMany(p => p.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryID);
      
            builder.Entity<Product>().ToTable("Products");
            builder.Entity<Product>().HasKey(p => p.ProductID);
            builder.Entity<Product>().Property(p => p.ProductID).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Product>().Property(p => p.ProductName).IsRequired().HasMaxLength(50);
            builder.Entity<Product>().Property(p => p.UnitPrice).IsRequired();
            builder.Entity<Product>().Property(p => p.UnitsInStock).IsRequired();
           


            /*Users*/
            builder.Entity<User>().ToTable("Users");
            builder.Entity<User>().HasKey(u=>u.UserId);
            builder.Entity<User>().Property(u=>u.UserId).IsRequired();
            builder.Entity<User>().Property(u => u.Password).IsRequired();
            builder.Entity<User>().Property(u => u.Email).IsRequired().HasMaxLength(50);
            builder.Entity<User>().Property(u => u.Name).HasMaxLength(50);

            /*Roles*/
            builder.Entity<Role>().ToTable("Roles");
            builder.Entity<Role>().HasKey(r => r.IdRole);
            builder.Entity<Role>().Property(r => r.IdRole).IsRequired();
            builder.Entity<Role>().Property(r => r.Name).IsRequired();

            builder.Entity<UserRole>().HasKey(ur => new { ur.UserId, ur.IdRole });
        }

    }
}
