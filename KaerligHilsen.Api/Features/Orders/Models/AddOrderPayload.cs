namespace KaerligHilsen.Api.Features.Orders.Models
{
    public class AddOrderPayload
    {
        public Order Order { get; }

        public AddOrderPayload(Order order)
        {
            Order = order;
        }
    }
}