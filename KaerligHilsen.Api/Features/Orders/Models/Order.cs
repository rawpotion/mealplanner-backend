using System;
using System.Collections.Generic;
using KaerligHilsen.Api.Features.Customers.Models;

namespace KaerligHilsen.Api.Features.Orders.Models
{
    public enum OrderStatus
    {
        NOT_PAYED,
        PROCESSING,
        PAYED,
        PENDING_SHIPPING,
        DELIVERED
    }

    public record Order(
        Guid Id,
        Customer Customer,
        ICollection<OrderItem> Items,
        OrderStatus OrderStatus);
}