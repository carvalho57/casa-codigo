using System.Collections.Generic;
using System.Linq;
using System;
using Flunt.Validations;
using CasaCodigo.ValueObjects;

namespace CasaCodigo.Entities
{
    public class Order : Entity
    {
        private Order() { }
        public Order(Customer customer)
        {
            AddNotifications(new Contract().Requires().IfNotNull(customer, order => order.Join(customer)));
            _items = new List<OrderItem>();
        }
        private List<OrderItem> _items { get; set; }
        public IEnumerable<OrderItem> Items => _items.AsReadOnly();
        public Customer Customer { get; private set; }
        public decimal Total
        {
            get
            {
                return _items.Sum(item => item.Total());
            }
        }
        public void AddItem(OrderItem item)
        {
            if (item == null)
                throw new ArgumentNullException("Order item");

            if (item.Valid)
                _items.Add(item);
        }
    }
}