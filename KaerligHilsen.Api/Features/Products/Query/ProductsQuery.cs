using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HotChocolate;
using KaerligHilsen.Api.Features.Products.Models;

namespace KaerligHilsen.Api.Features.Products.Query
{
    public class ProductsQuery
    {
        public IQueryable<Product> GetProducts([Service] IProductsRepository productsRepository)
            => productsRepository.GetAsIQueryable();

        public Task<Product> GetProductAsync(
            Guid id,
            ProductByIdDataLoader dataLoader,
            CancellationToken cancellationToken)
            => dataLoader.LoadAsync(
                id,
                cancellationToken);
    }
}