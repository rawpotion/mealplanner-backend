using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KaerligHilsen.Api.Database;
using KaerligHilsen.Api.Features.Orders.Models;
using Microsoft.EntityFrameworkCore;

namespace KaerligHilsen.Api.Features.Orders
{
    public interface IOrderRepository
    {
        Task<Order> AddAsync(Order order);
        IQueryable<Order> GetAsIQueryable();
        IQueryable<Order> GetManyById(IReadOnlyList<Guid> keys);
        Task<Order> GetByIdAsync(Guid id);
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

            return await GetByIdAsync(orderDto.Entity.Id);
        }

        public IQueryable<Order> GetAsIQueryable()
            => _db.Orders
                .Include(n => n.Customer)
                .Include(n => n.Items)
                .ThenInclude(i => i.Product)
                .Select(o => o.ToOrder());

        public IQueryable<Order> GetManyById(IReadOnlyList<Guid> keys)
            => _db.Orders
                .Include(n => n.Customer)
                .Include(n => n.Items)
                .ThenInclude(i => i.Product)
                .Where(o => keys.Contains(o.Id))
                .Select(o => o.ToOrder());

        public async Task<Order> GetByIdAsync(Guid id)
        {
            var orderDto = await _db.Orders
                .Include(n => n.Customer)
                .Include(n => n.Items)
                .ThenInclude(n => n.Product)
                .FirstOrDefaultAsync(o => o.Id == id);
            return orderDto.ToOrder();
        }
    }
}