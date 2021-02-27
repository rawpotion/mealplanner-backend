using System;
using System.Collections.Generic;
using KaerligHilsen.Api.Features.Customers.Models;

namespace KaerligHilsen.Api.Features.Orders.Models
{
    public record AddOrderInput(
        Guid Id,
        Customer Customer,
        ICollection<OrderItem> Items,
        OrderStatus OrderStatus);
}