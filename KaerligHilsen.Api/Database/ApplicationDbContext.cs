using System.Linq;
using KaerligHilsen.Api.Features.Customers.Models;
using KaerligHilsen.Api.Features.Orders.Models;
using KaerligHilsen.Api.Features.Products.Models;
using Microsoft.EntityFrameworkCore;

namespace KaerligHilsen.Api.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<ProductDto> Products { get; set; }
        public DbSet<OrderDto> Orders { get; set; }
        public DbSet<OrderItemDto> OrderItems { get; set; }
        public DbSet<CustomerDto> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<ProductDto>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
        }
    }
}