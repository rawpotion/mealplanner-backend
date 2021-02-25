using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KaerligHilsen.Api.Database;
using KaerligHilsen.Api.Features.Products.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace KaerligHilsen.Api.Features.Products
{
    public interface IProductsRepository
    {
        IQueryable<Product> GetAsIQueryable();
        Task<Product> Add(Product product);
        IQueryable<Product> GetManyById(IReadOnlyList<Guid> keys);
    }

    public class ProductsRepository : IProductsRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductsRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public IQueryable<Product> GetAsIQueryable() =>
            _db.Products
                .Select(p => p.ToProduct());

        public async Task<Product> Add(Product product)
        {
            var productDto = await _db.Products.AddAsync(product.ToProductDto());
            await _db.SaveChangesAsync();
            return productDto.Entity.ToProduct();
        }

        public IQueryable<Product> GetManyById(IReadOnlyList<Guid> keys)
            => _db.Products
                .Where(p => keys.Contains(p.Id))
                .Select(p => p.ToProduct());
    }
}