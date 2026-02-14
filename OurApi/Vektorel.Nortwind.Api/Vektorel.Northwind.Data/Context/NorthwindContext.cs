using Microsoft.EntityFrameworkCore;
using Vektorel.Northwind.Data.Entities;

namespace Vektorel.Northwind.Data.Context;

public class NorthwindContext : DbContext
{
    public NorthwindContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
}
