using System;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using KaerligHilsen.Api.Features.Orders.Models;

namespace KaerligHilsen.Api.Features.Orders.Mutations
{
    [ExtendObjectType(Name = "Mutation")]
    public class OrderMutation
    {
        public async Task<AddOrderPayload> AddOrderAsync(AddOrderInput input,
            [Service] IOrderRepository orderRepository)
        {
            var order = input.ToOrder(Guid.NewGuid(), OrderStatus.NOT_PAYED);

            var orderDto = await orderRepository.AddAsync(order);

            return new AddOrderPayload(orderDto);
        }
    }
}