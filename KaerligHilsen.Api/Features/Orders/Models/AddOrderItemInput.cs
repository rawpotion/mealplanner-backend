using System;

namespace KaerligHilsen.Api.Features.Orders.Models
{
    public record AddOrderItemInput(long Quantity, Guid ProductId);
}