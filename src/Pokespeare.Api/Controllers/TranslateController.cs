using System;
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
        public Translation Get(string name)
        {
            var translationResult = new Translation();
            try
            {
                var translation = _apiService.GetShakespeareTranslation(_apiService.GetPokemonDescription(name).Result);
                translationResult.Name = name;
                translationResult.Description = translation.Result;
            }
            catch (Exception ex)
            {
                translationResult.Name = name;
                translationResult.Description = ex.Message;
            }

            return translationResult;
        }
    }
}