using System;

namespace KaerligHilsen.Api.Features.Products.Models
{
    public record AddProductInput(
        string Name,
        string Description,
        DateTime Begins,
        DateTime Expires,
        long Quantity,
        string ImageUrl,
        bool LockedToZipCode = true,
        string ZipCode = "8541");
}