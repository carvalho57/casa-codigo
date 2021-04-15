using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CasaCodigo.Entities;
using Microsoft.EntityFrameworkCore;

namespace CasaCodigo.Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;

        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public async Task<bool> BookExist(Book book)
        {
            return await _context.Books.AnyAsync(b => b.ISBN == book.ISBN || b.Title == book.Title);
        }

        public List<Book> GetAll()
        {
            return  _context.Books.ToList();
        }

        public async Task<Book> GetBookById(Guid id)
        {
            return await _context.Books.FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<(Author, Category)> GetCategoryAndAuthor(Guid authorId, Guid categoryId)
        {
            var result = await (from author in _context.Authors
                                from category in _context.Categories
                                where author.Id == authorId && author.Id == authorId
                                select new { author, category })
                                .FirstOrDefaultAsync();
            return (result.author, result.category);
        }
    }
}