using System;
using KaerligHilsen.Api.Features.Products.Models;

namespace KaerligHilsen.Api.Features.Orders.Models
{
    public static class OrderItemExtensions
    {
        public static OrderItemDto ToOrderItemDto(this OrderItem from, Guid id)
            => new()
            {
                Id = id,
                Product = from.Product.ToProductDto(),
                Quantity = from.Quantity
            };

        public static OrderItem ToOrderItem(this OrderItemDto from)
            => new(
                from.Quantity,
                from.Product.ToProduct());
    }
}