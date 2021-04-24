using System;
using System.Threading.Tasks;
using CasaCodigo.Entities;

namespace CasaCodigo.Data.Repositories
{
    public interface IOrderRepository
    {
        void Add(Order order);
        Task<Order> GetById(Guid id);
    }
}