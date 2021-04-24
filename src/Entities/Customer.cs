using System;
using CasaCodigo.ValueObjects;
using Flunt.Validations;

namespace CasaCodigo.Entities
{

    public class Customer : Entity
    {
        protected Customer() { }
        public Customer(string firstName, string lastName, Document document, Email email, Address address, Phone phone)
        {
            if (document == null || email == null || address == null)
                throw new ArgumentNullException(nameof(Customer));

            AddNotifications(new Contract()
                .IsNotNullOrEmpty(firstName, nameof(FirstName), "O nome é obrigatório")
                .IsNotNullOrEmpty(lastName, nameof(LastName), "O sobrenome é obrigatório")
                .Join(document,email,address,phone)
            );

            FirstName = firstName;
            LastName = lastName;
            Document = document;
            Email = email;
            Address = address;
            Phone = phone;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public bool Active { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public Address Address { get; private set; }
        public Phone Phone { get; private set; }

        public void Activate() {
            Active = true;
        }
    }
}