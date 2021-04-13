using Flunt.Validations;

namespace CasaCodigo.ValueObjects
{
    public class AuthorDescription : ValueObject
    {
        private static short MAX_DESCRIPTION_LENGTH = 400;
        protected AuthorDescription() { }
        public AuthorDescription(string description)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(description, "Description", "A descrição é obrigatória")
                .HasMaxLen(description, MAX_DESCRIPTION_LENGTH, "Description", "A descrição não pode passar de 400 caracteres"));

            Value = description;
        }
        public string Value { get; protected set; }

        public override bool Equals(object obj)
        {
            AuthorDescription description = obj as AuthorDescription;
            if (ReferenceEquals(description, null))
                return false;

            return Value.Equals(description.Value);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}