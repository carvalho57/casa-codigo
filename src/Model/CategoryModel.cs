using System;
using CasaCodigo.Entities;
using CasaCodigo.ValueObjects;

namespace CasaCodigo.Models
{
    public class CategoryModel
    {                     
        public Guid Id {get;set;}
        public string Name { get; set; }

        public Category ToEntity()
        {
            return new Category(Name);
        }
                
        public static explicit operator CategoryModel(Category category)
        {
            return new CategoryModel()
            {
                Id = category.Id,
                Name = category.Name
            };
        }
    }
}