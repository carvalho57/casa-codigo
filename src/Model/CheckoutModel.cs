using System;
using CasaCodigo.Entities;
using CasaCodigo.ValueObjects;
using Flunt.Notifications;
using Flunt.Validations;

namespace CasaCodigo.Models
{
    public class CheckoutModel : Input
    {
        public CheckoutModel()
        {
            Order = new OrderModel();
        }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string AddressStreet { get; set; }
        public string Complement { get; set; }
        public string City { get; set; }
        public Guid Country { get; set; }
        public Guid State { get; set; }
        public string CEP { get; set; }
        public string Phone { get; set; }
        public OrderModel Order { get; set; }        
        public string CouponCode { get; set; }
        public bool SaveInformations { get; set; }
        public bool Validate()
        {
            Order.Validate();
            AddNotifications(new Contract()
                .Requires()                
                .Join(Order));
            return Valid;
        }
    }
}