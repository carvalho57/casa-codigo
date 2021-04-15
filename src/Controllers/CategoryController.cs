using System;
using System.Threading.Tasks;
using CasaCodigo.Data.Repositories;
using CasaCodigo.Helpers;
using CasaCodigo.Models;
using Microsoft.AspNetCore.Mvc;

namespace CasaCodigo.Controller
{
    [ApiController]
    [Route("category")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _repository;

        public CategoryController(ICategoryRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<ActionResult<Response>> GetCategoryById(Guid id)
        {
            var model =  (CategoryModel)(await _repository.GetById(id));
            return Ok(model);
        }
        [HttpPost]
        public async Task<ActionResult<Response>> CreateCategory(CategoryModel model)
        {
            var category = model.ToEntity();

            if (category.Invalid)
            {
                return BadRequest(ResponseHelper.CreateResponse("Informações inválidas para criar uma categoria", category.Notifications));
            }

            if (await _repository.CategoryExist(category))
            {
                return UnprocessableEntity(
                     ResponseHelper
                         .CreateResponse("Categoria já cadastrada", model));
            }

            _repository.Add(category);

            model = (CategoryModel)category;

            return CreatedAtAction(
                nameof(GetCategoryById),
                new { id = category.Id },
                ResponseHelper.CreateResponse("Categoria cadastrada com sucesso", model));

        }
    }
}