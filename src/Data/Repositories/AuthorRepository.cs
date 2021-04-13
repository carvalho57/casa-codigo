using System;
using System.Threading.Tasks;
using CasaCodigo.Data;
using CasaCodigo.Entities;
using Microsoft.EntityFrameworkCore;

namespace CasaCodigo.Data.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ApplicationDbContext _context;    

        public AuthorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(Author author)
        {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> AuthorExist(Author author)
        {
            return await _context.Authors.AnyAsync(_author => _author.Email.Address == author.Email.Address);
        }

        public async Task<Author> GetById(Guid id)
        {
            return await _context.Authors.AsNoTracking().FirstOrDefaultAsync(author => author.Id == id);
        }

    }

}