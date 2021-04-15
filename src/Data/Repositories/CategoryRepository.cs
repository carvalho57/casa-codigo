using System;
using System.Threading.Tasks;
using CasaCodigo.Entities;
using Microsoft.EntityFrameworkCore;

namespace CasaCodigo.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public async Task<bool> CategoryExist(Category category)
        {
            return await _context.Categories.AnyAsync(_category => _category.Name == category.Name);
        }

        public async Task<Category> GetById(Guid id)
        {
            return await _context.Categories.AsNoTracking().FirstAsync();
        }
    }
}