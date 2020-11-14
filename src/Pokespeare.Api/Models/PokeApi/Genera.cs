using Newtonsoft.Json;
namespace Pokespeare.Api.Models.PokeApi {

    public class Genera {
        [JsonProperty("genus")]
        public string Genus { get; set; }

        [JsonProperty("language")]
        public Language Language { get; set; }
    }

}