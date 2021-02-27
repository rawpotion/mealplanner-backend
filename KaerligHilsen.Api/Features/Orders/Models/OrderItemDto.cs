using System;
using System.ComponentModel.DataAnnotations;
using KaerligHilsen.Api.Features.Products.Models;

namespace KaerligHilsen.Api.Features.Orders.Models
{
    public class OrderItemDto
    {
        [Key]
        public Guid Id { get; init; }
        
        public long Quantity { get; init; }
        public ProductDto Product { get; init; }
    }
}