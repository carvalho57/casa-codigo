using Flunt.Validations;

namespace CasaCodigo.ValueObjects
{
    public class Address : ValueObject
    {
        protected Address() { }
        public Address(string street, string complement, string city, string cep, string country)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(street, nameof(Street), "O endereço é obrigatório")
                .IsNotNullOrEmpty(complement, nameof(Complement), "O complemento é obrigatório")
                .IsNotNullOrEmpty(city, nameof(City), "A cidade é obrigatória")
                .IsNotNullOrEmpty(country, nameof(Country), "O país é obrigatório")
                .IsNotNullOrEmpty(cep, nameof(CEP), "O CEP é obrigatório"));

            Street = street;
            Complement = complement;
            City = city;
            Country = country;
            CEP = cep;
        }

        public Address(string street, string complement, string city, string cep, string country, string state)
        : this(street, complement, city, cep, country)
        {
            State = state;
        }

        public string Street { get; private set; }
        public string Complement { get; private set; }
        public string City { get; private set; }
        public string Country { get; private set; }
        public string State { get; private set; }
        public string CEP { get; private set; }
    }
}