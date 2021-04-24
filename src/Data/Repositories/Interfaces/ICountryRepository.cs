using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CasaCodigo.Entities;

namespace CasaCodigo.Data.Repositories
{
    public interface ICountryRepository
    {
        Task<Country> GetCountryById(Guid id, bool include = false);
        Task<bool> CountryExist(Country country);
        void Add(Country country);
        Task<List<Country>> Get(bool include);
    }
}