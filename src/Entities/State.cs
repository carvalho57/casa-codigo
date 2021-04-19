using System;
using Flunt.Validations;

namespace CasaCodigo.Entities
{
    public class State : Entity
    {
        private State() { }
        public State(string name, string abbreviation, Country country)
        {
            if (country == null)
                throw new ArgumentNullException("Country cannot be null");

            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(name, nameof(Name), "O nome do estado é obrigatório")
                .IsNotNullOrEmpty(abbreviation, nameof(Abbreviation), "A UF ou código do estado é obrigatória"));

            Name = name;
            Abbreviation = abbreviation;
            Country = country;
        }

        public string Name { get; private set; }
        public string Abbreviation { get; private set; }
        public Country Country { get; private set; }
    }
}