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
            Customer = customer;            
        }
        private List<OrderItem> _items { get; set; } = new List<OrderItem>();
        public IEnumerable<OrderItem> Items => _items.AsReadOnly();
        public Customer Customer { get; private set; }
        public decimal Discount { get; private set; }
        public decimal Total
        {
            get
            {
                var total =  _items.Sum(item => item.Total());
                return total - (total * (Discount/100));
            }
        }
        public void ApplyCoupon(Coupon coupon){            
            AddNotifications(new Contract().Requires()
                .IsNotNull(coupon, nameof(Discount), "O cupom está inválido")
                .IsTrue(coupon.IsValid(), nameof(Discount), "O cupom está expirado")
            );
            if(Valid)
                Discount = (decimal)coupon.Percentage;
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