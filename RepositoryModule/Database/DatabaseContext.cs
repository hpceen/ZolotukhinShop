using Microsoft.EntityFrameworkCore;
using Repositories.Database.Entities;

namespace Repositories.Database;

public class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options)
{
    public DbSet<CategoryEntity> Categories { get; set; }
    public DbSet<ProductEntity> Products { get; set; }

    public DbSet<UserEntity> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CategoryEntity>(entity =>
        {
            entity.HasMany<ProductEntity>(category => category.Products)
                .WithOne(product => product.Category)
                .HasForeignKey(product => product.CategoryId);
        });
        modelBuilder.Entity<ProductEntity>(entity =>
        {
            entity.HasOne<CategoryEntity>(product => product.Category)
                .WithMany(category => category.Products)
                .HasForeignKey(product => product.CategoryId);
        });
        modelBuilder.Entity<UserEntity>(entity =>
        {
            entity.HasIndex(user => user.Phone)
                .IsUnique();
        });
    }
}