using inventory_management_system.Models;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Item> Items { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<InventoryTransaction> InventoryTransactions { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Item>().ToTable("Items");
        modelBuilder.Entity<Supplier>().ToTable("Suppliers");
        modelBuilder.Entity<InventoryTransaction>().ToTable("InventoryTransactions");
    }
}
