using CasaCodigo.Entities;

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
            _context.Order.Add(order);        
            _context.SaveChanges();
        }
    }
}