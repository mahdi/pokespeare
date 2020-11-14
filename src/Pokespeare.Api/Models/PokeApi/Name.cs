using Newtonsoft.Json;
namespace Pokespeare.Api.Models.PokeApi {

    public class Name {
        [JsonProperty("language")]
        public Language Language { get; set; }

        [JsonProperty("name")]
        public string PokemonName { get; set; }
    }

}