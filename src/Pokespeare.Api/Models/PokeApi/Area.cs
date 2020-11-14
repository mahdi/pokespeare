using System.Text.Json.Serialization;
namespace Pokespeare.Api.Models.PokeApi {

    public class Area {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }

}