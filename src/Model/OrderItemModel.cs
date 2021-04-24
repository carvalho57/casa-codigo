using System;
using Flunt.Notifications;
using Flunt.Validations;

namespace CasaCodigo.Models
{
    public class OrderItemModel : Input
    {        
        public Guid ItemId { get; set; }
        public int Quantity { get; set; }        

        public bool Validate()
        {
            AddNotifications(new Contract()
                .Requires()                
                .IsGreaterThan(Quantity,0, nameof(Quantity), "A quantidade deve ser maior que zero"));
            return Valid;
        }

      public override bool Equals(object obj)
        {
            if(!(obj is OrderItemModel other))
                return false;

            if (ReferenceEquals(other, this))
                return true;
            
            return other.ItemId == this.ItemId;
        }        

        public override int GetHashCode()
        {
            return ItemId.GetHashCode();
        }        
    }
}