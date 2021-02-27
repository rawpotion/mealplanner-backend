using System;

namespace KaerligHilsen.Api.Features.Customers.Models
{
    public record Customer(
        Guid Id,
        string FullName,
        string Address,
        string ZipCode,
        string? PhoneNumber,
        string Email);
}