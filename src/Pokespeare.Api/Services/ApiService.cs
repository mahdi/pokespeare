using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Pokespeare.Api.Helpers;
using Pokespeare.Api.Models.PokeApi;
using Pokespeare.Api.Models.ShakespeareApi;

namespace Pokespeare.Api.Services
{
    public class ApiService : IApiService
    {
        readonly IHttpClientFactory _httpClientFactory;

        public ApiService(IHttpClientFactory httpClientFactory) {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<string> GetPokemonDescription(string name)
        {
            using var httpClient = _httpClientFactory.CreateClient("PokiApi");
            var endpoint = string.Format(httpClient.BaseAddress.ToString(), name);
            var result = await httpClient.GetStringAsync(endpoint);
            var pokemon = JsonConvert.DeserializeObject<PokemonSpecies>(result);

            return pokemon.FlavorTextEntries.First(a => a.Language.Name.Equals("en")).FlavorText;
        }

        public async Task<string> GetShakespeareTranslation(string description) {
            using var httpClient = _httpClientFactory.CreateClient("ShakespeareApi");
            var endpoint = string.Format(httpClient.BaseAddress.ToString(), description.CleanText());
            var result = await httpClient.GetStringAsync(endpoint);
            var translatedDescription = JsonConvert.DeserializeObject<ShakespeareTranslation>(result);

            return translatedDescription.Contents.Translated;
        }
    }
}