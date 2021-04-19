using System;
using System.Threading.Tasks;
using CasaCodigo.Entities;

namespace CasaCodigo.Models
{
    public class StateModel 
    {        
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public Guid CountryId { get; set; }
        public string CountryName { get; set; }

        internal State ToEntity(Country country)
        {
            return new State(Name, Abbreviation, country);   
        }

        public static explicit operator StateModel(State state)
        {
            return new StateModel()
            {
                Id = state.Id,
                Name = state.Name,
                Abbreviation = state.Abbreviation,
                CountryId = state.Country == null? Guid.Empty : state.Country.Id,
                CountryName = state.Country?.Name
            };
        }
    }
}