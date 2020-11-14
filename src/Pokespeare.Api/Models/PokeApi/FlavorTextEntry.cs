using Newtonsoft.Json;
namespace Pokespeare.Api.Models.PokeApi {

    public class FlavorTextEntry {
        [JsonProperty("flavor_text")]
        public string FlavorText { get; set; }

        [JsonProperty("language")]
        public Language Language { get; set; }

        [JsonProperty("version")]
        public Version Version { get; set; }
    }

}