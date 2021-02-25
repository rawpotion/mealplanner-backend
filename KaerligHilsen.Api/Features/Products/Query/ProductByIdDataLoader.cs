using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GreenDonut;
using HotChocolate.DataLoader;
using KaerligHilsen.Api.Features.Products.Models;
using Microsoft.EntityFrameworkCore;

namespace KaerligHilsen.Api.Features.Products.Query
{
    public class ProductByIdDataLoader : BatchDataLoader<Guid, Product>
    {
        private readonly IProductsRepository _productsRepository;

        public ProductByIdDataLoader(IBatchScheduler batchScheduler, IProductsRepository productsRepository) : base(batchScheduler)
        {
            _productsRepository = productsRepository;
        }

        protected override async Task<IReadOnlyDictionary<Guid, Product>> LoadBatchAsync(IReadOnlyList<Guid> keys, CancellationToken cancellationToken)
        {
            var productsById = _productsRepository.GetManyById(keys);
            return await productsById.ToDictionaryAsync(t => t.Id,
                cancellationToken);
        }
    }
}