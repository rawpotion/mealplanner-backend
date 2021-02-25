using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KaerligHilsen.Api.Features.Products.Models
{
    public class ProductDto
    {
        [Key]
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public DateTime Begins { get; init; }
        public DateTime Expires { get; init; }
        public long Quantity { get; init; }
        public string ImageUrl { get; init; }
        public DateTime Created { get; init; }
        public bool LockedToZipCode { get; init; } = true;
        public string ZipCode { get; init; } = "8541";
    }
}