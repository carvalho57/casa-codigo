using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CasaCodigo.Entities;
using Microsoft.EntityFrameworkCore;

namespace CasaCodigo.Data.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly ApplicationDbContext _context;

        public CountryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Country country)
        {
            _context.Countries.Add(country);    
            _context.SaveChanges();
        }

        public async Task<bool> CountryExist(Country country)
        {
            return await _context.Countries.AnyAsync(c => c.Name == country.Name);
        }

        public async Task<List<Country>> Get(bool include)
        {
            var expression = from country in _context.Countries
                             select country;
            expression = include?  expression.Include(c => c.States): expression;

            return await expression.ToListAsync();
        }

        public async Task<Country> GetCountryById(Guid id, bool include = false)
        {
            var expression = _context.Countries.Where(c => c.Id == id);

            expression = include ? expression.Include(c => c.States)
                                 : expression;
            return await expression.AsNoTracking().FirstOrDefaultAsync();
        }

        
    }
}
