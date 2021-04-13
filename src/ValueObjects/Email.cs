using Flunt.Notifications;
using Flunt.Validations;

namespace CasaCodigo.ValueObjects
{
    public class Email : ValueObject
    {
        protected Email() { }
        public Email(string address)
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(address, nameof(Email), "O email é obrigatório")
                .IsEmail(address, nameof(Email), "O email tem que ter formato válido"));

            Address = address;
        }
        public string Address { get; protected set; }

        public override bool Equals(object obj)
        {
            Email email = obj as Email;
            if (ReferenceEquals(email, null))
                return false;

            return Address.Equals(email.Address);
        }
        public override int GetHashCode()
        {
            return Address.GetHashCode();
        }
    }
}