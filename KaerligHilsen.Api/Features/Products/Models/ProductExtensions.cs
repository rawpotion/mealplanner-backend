using System;

namespace KaerligHilsen.Api.Features.Products.Models
{
    public static class ProductExtensions
    {
        public static Product ToProduct(this ProductDto from)
            => new (
                from.Id,
                from.Name,
                from.Description,
                from.Price,
                from.Begins,
                from.Expires,
                from.Quantity,
                from.ImageUrl,
                from.Created,
                from.LockedToZipCode,
                from.ZipCode);

        public static Product ToProduct(this AddProductInput from, Guid id)
            => new (
                id,
                from.Name,
                from.Description,
                from.Price,
                from.Begins,
                from.Expires,
                from.Quantity,
                from.ImageUrl,
                DateTime.UtcNow,
                from.LockedToZipCode,
                from.ZipCode);

        public static ProductDto ToProductDto(this Product from)
            => new ProductDto
            {
                Id = from.Id,
                Name = from.Name,
                Description = from.Description,
                Price = from.Price,
                Begins = from.Begins,
                Expires = from.Expires,
                Quantity = from.Quantity,
                ImageUrl = from.ImageUrl,
                Created = from.Created,
                LockedToZipCode = from.LockedToZipCode,
                ZipCode = from.ZipCode
            };
    }
}