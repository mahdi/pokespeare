using Newtonsoft.Json;
namespace Pokespeare.Api.Models.PokeApi {

    public class EvolutionChain {
        [JsonProperty("url")]
        public string Url { get; set; }
    }

}