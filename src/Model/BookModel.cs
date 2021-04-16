using System;
using CasaCodigo.Entities;
using CasaCodigo.ValueObjects;

namespace CasaCodigo.Models
{
    public class BookModel
    {
        public Guid Id { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Resume { get; set; }
        public decimal Price { get; set; }
        public short NumberPages { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Guid CategoryId { get; set; }
        public string CategoryName { get; private set; }
        public Guid AuthorId { get; set; }
        public string AuthorName { get; set; }


        public static BookModel ToModel(Book book)
        {
            if(book == null)
            {
                Console.WriteLine("nullreference");
                return new BookModel();
            }

            return new BookModel()
            {
                Id = book.Id,
                AuthorId = book.Author.Id,
                AuthorName = book.Author.Name.Value,
                CategoryId = book.Category.Id,
                CategoryName = book.Category.Name,
                ISBN = book.ISBN,
                NumberPages = book.NumberPages,
                Price = book.Price,
                ReleaseDate = book.ReleaseDate,
                Resume = book.ResumeContent,
                Summary = book.Summary,
                Title = book.Title
            };
        }

        internal Book ToEntity(Author author, Category category)
        {
            return new Book(ISBN, Title, Summary, Resume, Price, NumberPages, ReleaseDate, category, author);
        }

        public static explicit operator BookModel(Book book)
        {
            return ToModel(book);
        }
    }
}