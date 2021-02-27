using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GreenDonut;
using HotChocolate.DataLoader;
using KaerligHilsen.Api.Features.Orders.Models;
using Microsoft.EntityFrameworkCore;

namespace KaerligHilsen.Api.Features.Orders.Queries
{
    public class OrderByIdDataLoader : BatchDataLoader<Guid, Order>
    {
        private readonly IOrderRepository _orderRepository;

        public OrderByIdDataLoader(IBatchScheduler batchScheduler, IOrderRepository orderRepository) : base(
            batchScheduler)
        {
            _orderRepository = orderRepository;
        }

        protected override async Task<IReadOnlyDictionary<Guid, Order>> LoadBatchAsync(IReadOnlyList<Guid> keys,
            CancellationToken cancellationToken)
        {
            var orderById = _orderRepository.GetManyById(keys);
            return await orderById
                .ToDictionaryAsync(t => t.Id,
                cancellationToken);
        }
    }
}