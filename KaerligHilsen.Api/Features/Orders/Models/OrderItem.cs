using KaerligHilsen.Api.Features.Products.Models;

namespace KaerligHilsen.Api.Features.Orders.Models
{
    public record OrderItem(
        long Quantity,
        Product Product);
}