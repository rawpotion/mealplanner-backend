using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using KaerligHilsen.Api.Features.Orders.Models;

namespace KaerligHilsen.Api.Features.Orders.Queries
{
    [ExtendObjectType(Name = "Query")]
    public class OrdersQuery
    {
        public IQueryable<Order> GetOrders(
            [Service] IOrderRepository orderRepository)
            => orderRepository.GetAsIQueryable();

        public Task<Order> GetOrderAsync(
            Guid id,
            OrderByIdDataLoader dataLoader,
            CancellationToken cancellationToken)
            => dataLoader.LoadAsync(id, cancellationToken);
    }
}