using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using KaerligHilsen.Api.Features.Customers.Models;

namespace KaerligHilsen.Api.Features.Orders.Models
{
    public class OrderDto
    {
        [Key]
        public Guid Id { get; init; }
        
        public CustomerDto Customer { get; init; }
        public ICollection<OrderItemDto> Items { get; init; }
        public OrderStatus OrderStatus { get; init; }
    }
}