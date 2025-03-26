using AspApi2Server.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspApi2Server.Domain;

public class ProductContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    public ProductContext(DbContextOptions<ProductContext> options)  : base(options)
    {
        
    }
}