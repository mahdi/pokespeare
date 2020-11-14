using System.Text.Json.Serialization; 
namespace Pokespeare.Api.Models.ShakespeareApi{ 

    public class ShakespeareTranslation    {
        [JsonPropertyName("success")]
        public Success Success { get; set; } 

        [JsonPropertyName("contents")]
        public Contents Contents { get; set; } 
    }

}