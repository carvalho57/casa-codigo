using System;
using System.Linq;
using System.Threading.Tasks;
using CasaCodigo.Entities;
using CasaCodigo.Helpers;
using CasaCodigo.Models;
using CasaCodigo.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CasaCodigo.Controller
{
    [ApiController]
    [Route("author")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepository _repository;

        public AuthorController(IAuthorRepository repository)
        {
            _repository = repository;
        }
    
        public IActionResult Index()
        {
            return Ok("Author Index");
        }
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<ActionResult<Response>> GetAuthorById(Guid id)
        {
            var author = await _repository.GetById(id);
            if (author == null) return NotFound(new {message = "Author não encontrado"});
            return Ok(ResponseHelper.CreateResponse("Usuário encontrado",AuthorModel.ToModel(author)));
        }

        [HttpPost]
        public async Task<ActionResult<Response>> CreateAuthor(AuthorModel model)
        {
            var author = model.ToEntity();

            if (author.Invalid)
            {
                return BadRequest(
                    ResponseHelper
                        .CreateResponse("Informações inválidas para criar um autor", author.Notifications)
                    );
            }

            if (await _repository.AuthorExist(author))
                return UnprocessableEntity(
                        ResponseHelper
                            .CreateResponse("Email já cadastrado", model));

            await _repository.Add(author);

            return CreatedAtAction(
                nameof(GetAuthorById),
                new { id = author.Id },
                ResponseHelper.CreateResponse("Autor cadastrado com sucesso", model));
        }
    }
}