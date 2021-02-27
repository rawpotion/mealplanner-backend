using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using KaerligHilsen.Api.Features.Products.Models;

namespace KaerligHilsen.Api.Features.Products.Query
{
    [ExtendObjectType(Name = "Query")]
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