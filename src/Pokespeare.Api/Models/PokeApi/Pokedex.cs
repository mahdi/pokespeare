using Newtonsoft.Json;
namespace Pokespeare.Api.Models.PokeApi {

    public class Pokedex {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

}