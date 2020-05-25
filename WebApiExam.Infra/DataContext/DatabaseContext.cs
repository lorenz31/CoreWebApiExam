using WebApiExam.Core.Models;

using Microsoft.EntityFrameworkCore;

namespace WebApiExam.Infra.DataContext
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region User Configuration
            builder
                .Entity<User>()
                .ToTable("Users")
                .HasKey(p => p.Id);

            builder
                .Entity<User>()
                .Property(p => p.Name)
                .IsRequired();

            builder
                .Entity<User>()
                .Property(p => p.Username)
                .IsRequired();

            builder
                .Entity<User>()
                .Property(p => p.Password)
                .IsRequired();

            builder
                .Entity<User>()
                .Property(p => p.Salt)
                .IsRequired();
            #endregion

            #region Categories Configuration
            builder
                .Entity<Category>()
                .ToTable("Categories")
                .HasKey(p => p.Id);

            builder
                .Entity<Category>()
                .HasOne(p => p.User)
                .WithMany(p => p.Categories)
                .HasForeignKey(p => p.UserId);

            builder
                .Entity<Category>()
                .Property(p => p.Name)
                .IsRequired();

            builder
                .Entity<Category>()
                .Property(p => p.IsDeleted)
                .IsRequired();
            #endregion

            #region Product Configuration
            builder
                .Entity<Product>()
                .ToTable("Product")
                .HasKey(p => p.Id);

            builder
                .Entity<Product>()
                .HasOne(p => p.User)
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.UserId);

            builder
                .Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder
                .Entity<Product>()
                .Property(p => p.Name)
                .IsRequired();

            builder
                .Entity<Product>()
                .Property(p => p.Description)
                .IsRequired();

            builder
                .Entity<Product>()
                .Property(p => p.Image);

            builder
                .Entity<Product>()
                .Property(p => p.IsDeleted)
                .IsRequired();
            #endregion
        }
    }
}
