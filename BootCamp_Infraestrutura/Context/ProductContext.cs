using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace BootCamp_Infraestrutura.Context;

public class ProductContext : DbContext
{
    public ProductContext(DbContextOptions<ProductContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products { get; set; } = null!;
}