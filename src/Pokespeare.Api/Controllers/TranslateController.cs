using Microsoft.AspNetCore.Mvc;
using Pokespeare.Api.Models;
using Pokespeare.Api.Services;

namespace Pokespeare.Api.Controllers
{
    [ApiController]
    [Route("pokemon")]
    public class TranslateController : ControllerBase
    {
        private readonly IApiService _apiService;
        public TranslateController(IApiService apiService) {
            _apiService = apiService;
        }

        [HttpGet]
        [Route("{name}")]
        public Translation Get(string name) {
            var translation = _apiService.GetShakespeareTranslation(_apiService.GetPokemonDescription(name).Result);
            return new Translation { Name = name, Description = translation.Result };
        }
    }
}