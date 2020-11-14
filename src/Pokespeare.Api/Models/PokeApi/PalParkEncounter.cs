using Newtonsoft.Json;
namespace Pokespeare.Api.Models.PokeApi {

    public class PalParkEncounter {
        [JsonProperty("area")]
        public Area Area { get; set; }

        [JsonProperty("base_score")]
        public int BaseScore { get; set; }

        [JsonProperty("rate")]
        public int Rate { get; set; }
    }

}