namespace KaerligHilsen.Api.Features.Customers.Models
{
    public record AddCustomerInput(
        string FullName,
        string Address,
        string ZipCode,
        string? PhoneNumber,
        string Email);
}