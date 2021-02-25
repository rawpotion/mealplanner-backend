namespace KaerligHilsen.Api.Features.Products.Models
{
    public class AddProductPayload
    {
        public Product Product { get; }

        public AddProductPayload(Product product)
        {
            Product = product;
        }
    }
}