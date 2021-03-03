using System;
using KaerligHilsen.Api.Features.Products.Models;

namespace KaerligHilsen.Api.Features.Orders.Models
{
    public record OrderItem(
        long Quantity,
        Guid ProductId,
        Product Product);
}