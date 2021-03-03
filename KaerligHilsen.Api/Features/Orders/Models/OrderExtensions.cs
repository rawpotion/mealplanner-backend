using System;
using System.Linq;
using KaerligHilsen.Api.Features.Customers.Models;

namespace KaerligHilsen.Api.Features.Orders.Models
{
    public static class OrderExtensions
    {
        public static Order ToOrder(this AddOrderInput from, Guid id, OrderStatus status)
            => new(
                id,
                from.Customer.ToCustomer(Guid.NewGuid()),
                from.Items
                    .Select(i => i.ToOrderItem())
                    .ToList(),
                status);

        public static OrderDto ToOrderDto(this Order from)
            => new()
            {
                Id = from.Id,
                Customer = from.Customer.ToCustomerDto(),
                Items = from.Items
                    .Select(i => i
                        .ToOrderItemDto(
                            Guid.NewGuid()))
                    .ToList(),
                OrderStatus = from.OrderStatus
            };

        public static Order ToOrder(this OrderDto from)
            => new(
                from.Id,
                from.Customer.ToCustomer(),
                from.Items
                    .Select(i => i.ToOrderItem())
                    .ToList(),
                from.OrderStatus);

        public static OrderItem ToOrderItem(this AddOrderItemInput from)
            => new(
                from.Quantity,
                from.ProductId,
                null);
    }
}