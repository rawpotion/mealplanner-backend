using System;

namespace KaerligHilsen.Api.Features.Products.Models
{
    public record Product(
        Guid Id,
        string Name,
        string Description,
        DateTime Begins,
        DateTime Expires,
        long Quantity,
        string ImageUrl,
        DateTime Created,
        bool LockedToZipCode,
        string ZipCode);
}