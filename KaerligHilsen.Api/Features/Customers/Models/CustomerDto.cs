using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using KaerligHilsen.Api.Features.Orders.Models;

namespace KaerligHilsen.Api.Features.Customers.Models
{
    public class CustomerDto
    {
        [Key]
        public Guid Id { get; init; }
        public string FullName { get; init; }
        public string Address { get; init; }
        public string ZipCode { get; init; }
        public string? PhoneNumber { get; init; }
        public string Email { get; init; }
        
        public ICollection<OrderDto> Orders { get; set; }
    }
}