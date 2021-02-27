using System.Security.Cryptography;

namespace KaerligHilsen.Api.Features.Customers.Models
{
    public static class CustomerExtensions
    {
        public static CustomerDto ToCustomerDto(this Customer from)
            => new()
            {
                Id = from.Id,
                Address = from.Address,
                Email = from.Email,
                FullName = from.FullName,
                PhoneNumber = from.PhoneNumber,
                ZipCode = from.ZipCode
            };

        public static Customer ToCustomer(this CustomerDto from)
            => new(
                from.Id,
                from.FullName,
                from.Address,
                from.ZipCode,
                from.PhoneNumber,
                from.Email);
    }
}