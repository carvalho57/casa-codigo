using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CasaCodigo.Entities;

namespace CasaCodigo.Data.Repositories
{
    public interface IBookRepository 
    {
        void Add(Book book);
        Task<List<Book>> GetAll();
        Task<bool> BookExist(Book book);
        Task<(Author, Category)> GetCategoryAndAuthor(Guid author, Guid category);
        Task<Book> GetBookById(Guid id);
    }
}