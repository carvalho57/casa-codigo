using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CasaCodigo.Data.Repositories;
using CasaCodigo.Entities;
using CasaCodigo.Models;
using CasaCodigo.ValueObjects;

namespace CasaCodigo.Services 
{
    public class OrderHandler
    {        
        private readonly ICountryRepository _countryRepository;
        private readonly IStateRepository _stateRepository;
        private readonly IBookRepository _bookRepository;   
        private readonly ICustomerRepository _customerRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderHandler(ICountryRepository countryRepository, IStateRepository stateRepository, IBookRepository bookRepository, IOrderRepository orderRepository)
        {
            _countryRepository = countryRepository;
            _stateRepository = stateRepository;
            _bookRepository = bookRepository;
            _orderRepository = orderRepository;
        }

        private void ValidateStateOfCountry(CheckoutModel model,State state, Country country)
        {                    
            if (state == null)
                model.AddNotification("State", "Estado não encontrado");

            if (state != null && state.Country.Id != country.Id)
                model.AddNotification("State", "Esse estado não pertence a esse país");
        }                
        
        public async Task<Output> Handle(CheckoutModel model)       
        {
            var country = await _countryRepository.GetCountryById(model.Country);
            State state = null;

            if (model.State != null && model.State != Guid.Empty)
                state = await _stateRepository.GetStateById(model.State, include: true);

            ValidateStateOfCountry(model, state, country);

            var document = new Document(model.Document);
            var email = new Email(model.Email);
            var address = new Address(model.AddressStreet, model.Complement, model.City, model.CEP, country?.Name, state?.Name);
            var phone = new Phone(model.Phone);
            var customer = new Customer(model.FirstName, model.LastName, document, email, address, phone);                    
            

            model.Validate();
            model.AddNotifications(customer);
                    
            if (model.Invalid)
                return new Output(false, model, model.Notifications, "Pedido inválido");

            var order = new Order(customer);

            var books = _bookRepository.Get(model.Order.Items.Select(item => item.ItemId));

            if(books.Count != model.Order.Items.Distinct().Count())
                order.AddNotification("Carrinho", "Alguns itens do carrinho não foram encontrados em nossa base de dados");

            foreach(var item in model.Order.Items)
            {
                var book = books.FirstOrDefault(x => x.Id == item.ItemId);
                order.AddItem(new OrderItem(book, item.Quantity));
            }

            if(order.Total != model.Order.Total)
                order.AddNotification("Total", "O total calculado não confere");
            
            if(order.Invalid)
                return new Output(false, order, order.Notifications, "Pedido inválido");            
            
            if(model.SaveInformations)
                order.Customer.Activate();

            _orderRepository.Add(order);

            return new Output(true, "Pedido adicionado com sucesso", order);
        }

    }
}
