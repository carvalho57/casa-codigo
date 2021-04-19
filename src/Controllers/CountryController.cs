using CasaCodigo.Data.Repositories;
using CasaCodigo.Models;
using CasaCodigo.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace CasaCodigo.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class CountryController : ControllerBase
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IStateRepository _stateRepository;

        public CountryController(ICountryRepository countryRepository, IStateRepository stateRepository)
        {
            _countryRepository = countryRepository;
            _stateRepository = stateRepository;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<Response>> Get()
        {
            var countries = await _countryRepository.Get(include: true);
            if (countries == null)
                return NotFound(ResponseHelper.CreateResponse("Nenhum país encontrado"));

            var countriesResult = countries.Select(c => (CountryModel)c).ToList();
            return Ok(ResponseHelper.CreateResponse("Paises encontrados", countriesResult));
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<ActionResult<Response>> GetCountryById(Guid id, bool includestates)
        {
            var country = await _countryRepository.GetCountryById(id, include: includestates);
            if (country == null)
                return NotFound(ResponseHelper.CreateResponse("Pais não encontrado"));

            return Ok(ResponseHelper.CreateResponse("Pais encontrado com sucesso", (CountryModel)country));
        }

        [HttpPost]
        [Route("state")]
        public async Task<ActionResult<Response>> CreateState(StateModel model)
        {
            var country = await _countryRepository.GetCountryById(model.CountryId, include: false);

            if (country == null)
                return NotFound(ResponseHelper.CreateResponse("Pais não encontrado"));

            var state = model.ToEntity(country);

            if (state.Invalid)
                return BadRequest(ResponseHelper.CreateResponse("Informações inválidas para cadastrar um estado", model));

            if (await _stateRepository.StateExist(state))
                return BadRequest(ResponseHelper.CreateResponse("Esse estado já foi cadastrado", model));

            _stateRepository.Add(state);

            return Ok(ResponseHelper.CreateResponse("Estado cadastrado com sucesso!", (StateModel)state));
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Response>> CreateCountry(CountryModel model)
        {
            var country = model.ToEntity();

            if (country.Invalid)
                return BadRequest(ResponseHelper.CreateResponse("Informações inválidas para cadastrar um país", model));

            if (await _countryRepository.CountryExist(country))
                return BadRequest(ResponseHelper.CreateResponse("Esse país já foi cadastrado", model));

            _countryRepository.Add(country);

            return Ok(ResponseHelper.CreateResponse("País cadastrado com sucesso!", (CountryModel)country));
        }
    }
}