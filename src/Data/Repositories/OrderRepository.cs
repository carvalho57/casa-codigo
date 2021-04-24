using System;
using System.Threading.Tasks;
using CasaCodigo.Entities;
using Microsoft.EntityFrameworkCore;

namespace CasaCodigo.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(Order order)
        {
            _context.Orders.Add(order);        
            _context.SaveChanges();
        }

        public async Task<Order> GetById(Guid id)
        {
            return await _context.Orders.AsNoTracking()
                .Include(o => o.Items)
                    .ThenInclude(i => i.Book)
                .Include(o => o.Customer)
                    .ThenInclude(c => c.Email)
                .Include(o => o.Customer)
                    .ThenInclude(c => c.Document)
                .Include(o => o.Customer)
                    .ThenInclude(c => c.Phone)
                .FirstOrDefaultAsync(o => o.Id == id);
        }
    }
}