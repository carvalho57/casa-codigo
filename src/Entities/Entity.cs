using System;
using Flunt.Notifications;

namespace CasaCodigo.Entities
{
    public abstract class Entity : Notifiable
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; protected set; }
        
        public override bool Equals(object obj)
        {
            if(!(obj is Entity other))
                return false;

            if (ReferenceEquals(other, this))
                return true;
            
            return EqualsCore(other);
        }

        protected virtual bool EqualsCore(object other)
        {
            return Id.Equals(((Entity)other).Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }        
    }
}