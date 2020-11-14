using Newtonsoft.Json;
namespace Pokespeare.Api.Models.PokeApi {

    public class Variety {
        [JsonProperty("is_default")]
        public bool IsDefault { get; set; }

        [JsonProperty("pokemon")]
        public Pokemon Pokemon { get; set; }
    }

}