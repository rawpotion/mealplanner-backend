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
                ProductId = from.ProductId,
                Quantity = from.Quantity
            };

        public static OrderItem ToOrderItem(this OrderItemDto from)
            => new(
                from.Quantity,
                from.ProductId,
                from.Product.ToProduct());
    }
}