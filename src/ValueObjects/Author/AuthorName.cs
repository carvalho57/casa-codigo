using Flunt.Notifications;
using Flunt.Validations;

namespace CasaCodigo.ValueObjects
{
    public class AuthorName : ValueObject
    {
        protected AuthorName() { }
        public AuthorName(string name)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(name, nameof(AuthorName), "Nome do author é obrigatório"));


            Value = name;
        }
        public string Value { get; protected set; }
        
        public override bool Equals(object obj)
        {                
            AuthorName name = obj as AuthorName;
            if (ReferenceEquals(name, null))
                return false;
                                    
            return Value.Equals(name.Value);
        }
                
        public override int GetHashCode()
        {            
            return Value.GetHashCode();
        }
    }
}