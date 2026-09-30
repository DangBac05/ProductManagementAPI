using Microsoft.EntityFrameworkCore;
using ProductManagementAPI.Entities;

namespace ProductManagementAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("PRODUCTS");

            entity.HasKey(x => x.Id);

            entity.Property(x => x.Id)
                .HasColumnName("ID");

            entity.Property(x => x.Name)
                .HasColumnName("NAME");

            entity.Property(x => x.Price)
                .HasColumnName("PRICE");

            entity.Property(x => x.Quantity)
                .HasColumnName("QUANTITY");

            entity.Property(x => x.Description)
                .HasColumnName("DESCRIPTION");
        });

        base.OnModelCreating(modelBuilder);
    }
}