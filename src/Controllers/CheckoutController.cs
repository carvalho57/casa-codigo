using CasaCodigo.Models;
using CasaCodigo.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CasaCodigo.Helpers;

using CasaCodigo.Services;
using System;
using CasaCodigo.Entities;

namespace CasaCodigo.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class CheckoutController : ControllerBase
    {
        private readonly OrderHandler _handler;

        public CheckoutController(OrderHandler handler)
        {
            _handler = handler;
        }

        [HttpGet]
        public ActionResult GetOrderById(Guid id)
        {
            return Ok($"Pedido {id}");
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Response>> Checkout(CheckoutModel model)
        {
            var output = await _handler.Handle(model);

            if (!output.Sucess)
                return BadRequest(ResponseHelper.CreateResponse(output.Message, output.Data, output.Notifications));

            return CreatedAtAction(nameof(GetOrderById), new {id = ((Order)output.Data).Id}, "Pedido realizado com sucesso");
        }

    }
}




