using CasaCodigo.Entities;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;

namespace CasaCodigo.Models
{
    public class OrderModel : Input
    {
        public OrderModel()
        {
            Items = new List<OrderItemModel>();
        }
        public decimal Total { get; set; }
        public List<OrderItemModel> Items { get; set; }

        public bool Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsGreaterThan(Total, 0, nameof(Total), "O total tem que ser maior que zero")
                .IsGreaterThan(Items.Count, 0, nameof(Items), "O pedido deve contar pelo menos 1 item"));

            Items.ForEach(item => {
                item.Validate();
                AddNotifications(item);
            });
            return Valid;
        }

    }
}