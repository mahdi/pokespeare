using Newtonsoft.Json;
namespace Pokespeare.Api.Models.PokeApi {

    public class PokedexNumber {
        [JsonProperty("entry_number")]
        public int EntryNumber { get; set; }

        [JsonProperty("pokedex")]
        public Pokedex Pokedex { get; set; }
    }

}