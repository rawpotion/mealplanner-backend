using System;
using System.Collections.Generic;

namespace KaerligHilsen.Api.Features.Orders.Models
{
    public record Order(
        Guid Id,
        ICollection<OrderItem> Items);
}