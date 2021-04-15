using System;
using Flunt.Validations;

namespace CasaCodigo.Entities
{
    public class Book : Entity
    {
        private Book() { }
        public Book(string isbn, string title, string summary, string resume, decimal price, short numberPages, DateTime releaseDate, Category category, Author author)
        {
            if (author == null || category == null)
                throw new ArgumentNullException("author or category cannot be null");

            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(isbn, nameof(ISBN), "O ISBN é obrigátorio e tem formato livre")
                .IsNotNullOrEmpty(title, nameof(Title), "O título é obrigatório")
                .IsNotNullOrWhiteSpace(resume, "Resume", "O resumo é obrigatório")
                .HasMaxLen(resume, 500, "Resume", "O resumo deve ter no máximo 500 caracteres")
                .IsGreaterOrEqualsThan(price, 20, nameof(Price), "O preço é no mínimo 20 reais")
                .IsGreaterOrEqualsThan(numberPages, 100, nameof(NumberPages), "O numero de páginas é no mínimo 100")
                .IsGreaterThan(releaseDate, DateTime.UtcNow, nameof(ReleaseDate), "A data de lançamento deve ser no futuro")
            );

            ISBN = isbn;
            Title = title;
            Summary = summary;
            ResumeContent = resume;
            Price = price;
            NumberPages = numberPages;
            ReleaseDate = releaseDate;
            Category = category;
            Author = author;
        }

        public string ISBN { get; private set; }
        public string Title { get; private set; }
        public string Summary { get; private set; }
        public string ResumeContent { get; private set; } //Abstract
        public decimal Price { get; private set; }
        public short NumberPages { get; private set; }
        public DateTime ReleaseDate { get; private set; }
        public Category Category { get; private set; }
        public Author Author { get; set; }       
    }
}