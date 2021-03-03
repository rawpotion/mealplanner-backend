using System.Collections.Generic;
using KaerligHilsen.Api.Features.Customers.Models;

namespace KaerligHilsen.Api.Features.Orders.Models
{
    public record AddOrderInput(
        AddCustomerInput Customer,
        ICollection<AddOrderItemInput> Items);
}