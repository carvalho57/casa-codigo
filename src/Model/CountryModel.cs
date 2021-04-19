using System;
using System.Collections.Generic;
using System.Linq;
using CasaCodigo.Entities;

namespace CasaCodigo.Models
{
    public class CountryModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<StateModel> States { get; set; }

        public Country ToEntity()
        {
            return new Country(Name);
        }
        public static explicit operator CountryModel(Country country)
        {
            return new CountryModel()
            {
                Id = country.Id,
                Name = country.Name,
                States = country.States.Select(s => (StateModel)s)
            };
        }
    }
}