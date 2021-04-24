using System;
using CasaCodigo.Entities;
using CasaCodigo.ValueObjects;

namespace CasaCodigo.Models
{
    public class AuthorModel : Input
    {                     
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get;  set; }
        public string Description { get; set; }

        public Author ToEntity()
        {
            return new Author(new AuthorName(Name), new Email(Email), new AuthorDescription(Description));
        }

        public static AuthorModel ToModel(Author author)
        {
            return new AuthorModel
            {
                Id = author.Id,
                Name = author.Name.Value,
                Email = author.Email.Address,
                Description = author.Description.Value
            };
        }
    }
}