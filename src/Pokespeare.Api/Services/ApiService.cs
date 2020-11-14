using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Pokespeare.Api.Helpers;
using Pokespeare.Api.Models.PokeApi;
using Pokespeare.Api.Models.ShakespeareApi;

namespace Pokespeare.Api.Services {
    public class ApiService : IApiService {
        readonly IHttpClientFactory _httpClientFactory;

        public ApiService(IHttpClientFactory httpClientFactory) {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<string> GetPokemonDescription(string name) {
            var pokemon = new PokemonSpecies();
            var description = string.Empty;
            using var httpClient = _httpClientFactory.CreateClient("PokiApi");
            var endpoint = string.Format(httpClient.BaseAddress.ToString(), name);
            var response = await httpClient.GetAsync(endpoint);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                pokemon = JsonConvert.DeserializeObject<PokemonSpecies>(result);
                description = pokemon.FlavorTextEntries.Any(a => a.Language.Name.Equals("en")) ?
                    pokemon.FlavorTextEntries.First(a => a.Language.Name.Equals("en")).FlavorText : 
                    $"Sorry! There is no description for {name} in English to translate!";
            }
            else
            {
                throw new Exception(
                    $"Sorry! Couldn't reach PokiAPI; API response code is {response.StatusCode.ToString()}");
            }

            return description;
        }

        public async Task<string> GetShakespeareTranslation(string description) {
            ShakespeareTranslation translatedDescription = new ShakespeareTranslation();
            using var httpClient = _httpClientFactory.CreateClient("ShakespeareApi");
            var endpoint = string.Format(httpClient.BaseAddress.ToString(), description.CleanText());
            var response = await httpClient.GetAsync(endpoint);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                translatedDescription = JsonConvert.DeserializeObject<ShakespeareTranslation>(result);
            }
            else
            {
                throw new Exception("API limit reached"); // Shakespeare API is limited to 5 requeste per hour; otherwise returns 429 HTTP status code
            }
            
            return translatedDescription.Contents.Translated;
        }
    }
}