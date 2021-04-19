using System;
using System.Collections.Generic;
using System.Linq;
using Flunt.Validations;

namespace CasaCodigo.Entities
{
    public class Country : Entity
    {
        private Country() { }
        private List<State> _states = new List<State>();
        public string Name { get; private set; }
        public IReadOnlyCollection<State> States => _states.AsReadOnly();

        public Country(string name)
        {
            AddNotifications(
                new Contract()
                .Requires()
                .IsNotNullOrEmpty(name, nameof(Name), "O nome é obrigátorio")
            );
            Name = name;
        }
    }
}