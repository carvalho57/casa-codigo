using System;
using System.Threading.Tasks;
using CasaCodigo.Entities;

namespace CasaCodigo.Data.Repositories
{
    public interface ICategoryRepository 
    {

        Task<Category> GetById(Guid id);
        void Add(Category category);

        Task<bool> CategoryExist(Category category);
    }
}