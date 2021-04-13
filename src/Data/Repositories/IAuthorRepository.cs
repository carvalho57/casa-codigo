using System;
using System.Threading.Tasks;
using CasaCodigo.Entities;

namespace CasaCodigo.Data.Repositories
{
    public interface IAuthorRepository
    {
        Task<Author> GetById(Guid id);

        Task<bool> AuthorExist(Author author);
        Task Add(Author author);
    }
}