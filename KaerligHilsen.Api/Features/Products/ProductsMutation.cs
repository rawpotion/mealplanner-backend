using System;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using KaerligHilsen.Api.Features.Products.Models;

namespace KaerligHilsen.Api.Features.Products
{
    [ExtendObjectType(Name = "Mutation")]
    public class ProductsMutation
    {
        public async Task<AddProductPayload> AddProductAsync(
            AddProductInput input,
            [Service] IProductsRepository productsRepository)
        {
            var product = input.ToProduct(Guid.NewGuid());
            
            var productDto = await productsRepository.Add(product);
            
            return new AddProductPayload(productDto);
        }
    }
}