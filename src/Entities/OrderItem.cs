using System;
using Flunt.Validations;

namespace CasaCodigo.Entities
{
    public class OrderItem : Entity
    {
        private OrderItem() { }
        public OrderItem(Book book, int quantity)
        {

            AddNotifications(new Contract()
                    .Requires()
                    .IsNotNull(book, nameof(Book), "Livro inválido")
                    .IsGreaterThan(quantity, 0, nameof(Quantity), "A quantidade deve ser maior que zero")
                );

            Book = book;
            Price = book != null ? book.Price : 0;
            Quantity = quantity;
        }

        public Book Book { get; private set; }
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }

        public decimal Total()
        {
            return Price * Quantity;
        }
    }
}