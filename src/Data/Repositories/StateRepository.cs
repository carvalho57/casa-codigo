using System;
using System.Threading.Tasks;
using CasaCodigo.Entities;
using Microsoft.EntityFrameworkCore;

namespace CasaCodigo.Data.Repositories
{
    public class StateRepository : IStateRepository
    {
        private readonly ApplicationDbContext _context;

        public StateRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(State state)
        {            
            _context.States.Add(state);
            _context.Entry(state.Country).State = EntityState.Unchanged;
            _context.SaveChanges();
        }

        public async Task<State> GetStateById(Guid state, bool include = false)
        {
            var expression = _context.States.AsNoTracking();
            expression = include ? expression.Include(c => c.Country) : expression;

            return await expression.FirstOrDefaultAsync();
        }

        public Task<bool> StateExist(State state)
        {
            return _context.States.AnyAsync(s => s.Name == state.Name && s.Country.Name == state.Country.Name);
        }
    }
}