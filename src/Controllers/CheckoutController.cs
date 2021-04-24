using CasaCodigo.Models;
using CasaCodigo.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CasaCodigo.Helpers;
using CasaCodigo.Services;
using System;
using CasaCodigo.Entities;
using System.Linq;

namespace CasaCodigo.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class CheckoutController : ControllerBase
    {
        private readonly OrderHandler _handler;
        private readonly IOrderRepository _orderRepository;

        public CheckoutController(OrderHandler handler, IOrderRepository orderRepository)
        {
            _handler = handler;
            _orderRepository = orderRepository;
        }

        [HttpGet]
        public async Task<ActionResult<Response>> GetOrderById(Guid id)
        {
            var order = await _orderRepository.GetById(id);
            if (order == null)
                return BadRequest(ResponseHelper.CreateResponse("Pedido não encontrado", id));

            return Ok(ResponseHelper.CreateResponse("Aqui esta seu pedido", 
            new
            {
                Id = order.Id,
                FirstName = order.Customer.FirstName,
                Email = order.Customer.Email.Address,
                SubTotal = order.SubTotal,
                Total = order.Total,
                Items = order.Items.Select(item => new {Name = item.Book.Title, Quantity = item.Quantity})
            }));
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Response>> Checkout(CheckoutModel model)
        {
            var output = await _handler.Handle(model);

            if (!output.Sucess)
                return BadRequest(ResponseHelper.CreateResponse(output.Message, output.Notifications));

            return CreatedAtAction(nameof(GetOrderById), new { id = ((Order)output.Data).Id }, "Pedido realizado com sucesso");
        }

    }
}




