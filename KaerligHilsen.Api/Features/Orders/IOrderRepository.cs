using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KaerligHilsen.Api.Database;
using KaerligHilsen.Api.Features.Orders.Models;
using KaerligHilsen.Api.Features.Products.Models;

namespace KaerligHilsen.Api.Features.Orders
{
    public interface IOrderRepository
    {
        Task<Order> AddAsync(Order order);
        IQueryable<Order> GetAsIQueryable();
        IQueryable<Order> GetManyById(IReadOnlyList<Guid> keys);
    }

    public class OrderRepository : IOrderRepository
    {
        readonly ApplicationDbContext _db;

        public OrderRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        
        public async Task<Order> AddAsync(Order order)
        {
            var orderDto = await _db.Orders.AddAsync(order.ToOrderDto());
            await _db.SaveChangesAsync();
            return orderDto.Entity.ToOrder();
        }

        public IQueryable<Order> GetAsIQueryable()
            => _db.Orders
                .Select(o => o.ToOrder());

        public IQueryable<Order> GetManyById(IReadOnlyList<Guid> keys)
            => _db.Orders
                .Where(o => keys.Contains(o.Id))
                .Select(o => o.ToOrder());

    }
}