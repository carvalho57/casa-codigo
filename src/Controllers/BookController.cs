using System;
using System.Threading.Tasks;
using CasaCodigo.Data.Repositories;
using CasaCodigo.Helpers;
using CasaCodigo.Models;
using Microsoft.AspNetCore.Mvc;

namespace CasaCodigo.Controller
{
    [ApiController]
    [Route("book")]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _repository;

        public BookController(IBookRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<Response>> GetBookById(Guid id)
        {
            return Ok(ResponseHelper.CreateResponse("Livro encontrado", await _repository.GetBookById(id)));
        }

        [HttpPost]
        public async Task<ActionResult<Response>> CreateBook(BookModel model)
        {
            var (category, author) = await _repository.GetCategoryAndAuthor(model.AuthorId, model.CategoryId);

            if(category == null || author == null)
            {
                return NotFound(
                    ResponseHelper
                        .CreateResponse("Author ou categoria não foram encontrados", model)
                    );
            }

            var book = model.ToEntity(category, author);

            if (book.Invalid)
            {
                return BadRequest(
                    ResponseHelper
                        .CreateResponse("Informações inválidas para criar um livro", book.Notifications)
                    );
            }            

            if (await _repository.BookExist(book))
            {
                return BadRequest(
                    ResponseHelper
                        .CreateResponse("O livro já existe", book.Notifications)
                    );
            }

            _repository.Add(book);

            return Ok(ResponseHelper.CreateResponse("Livro cadastrado com sucesso", (BookModel)book));
        }
    }
}