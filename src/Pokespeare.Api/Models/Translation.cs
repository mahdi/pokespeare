using System.Text.Json.Serialization;

namespace Pokespeare.Api.Models {

    public class Translation {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}