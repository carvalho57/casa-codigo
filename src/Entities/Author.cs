using System;
using System.Collections.Generic;
using CasaCodigo.ValueObjects;
using Flunt.Notifications;
using Flunt.Validations;

namespace CasaCodigo.Entities
{
    public class Author : Entity
    {
        private Author() { } // EF CORE
        public Author(AuthorName name, Email email, AuthorDescription description)
        {
            if (name == null || email == null || description == null)
                throw new ArgumentNullException();

            AddNotifications(new Contract().Join(name, email, description));

            Name = name;
            Email = email;
            Description = description;
            CreateDate = DateTime.UtcNow;
        }

        public AuthorName Name { get; private set; }
        public Email Email { get; private set; }
        public AuthorDescription Description { get; private set; }
        public DateTime CreateDate { get; private set; }
        private List<Book> _books = new List<Book>();
        public IEnumerable<Book> Books => _books.AsReadOnly();


        public void ChangeEmail(Email email)
        {
            if (email == null)
                throw new ArgumentNullException("email");
            Email = email;
        }

        public void ChangeName(AuthorName name)
        {
            if (name == null)
                throw new ArgumentNullException("name");
            Name = name;
        }

        public void ChangeDescription(AuthorDescription description)
        {
            if (description == null)
                throw new ArgumentNullException("description");
            Description = description;
        }

    }
}