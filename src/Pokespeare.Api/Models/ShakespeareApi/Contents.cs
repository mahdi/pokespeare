using System.Text.Json.Serialization; 
namespace Pokespeare.Api.Models.ShakespeareApi{ 

    public class Contents    {
        [JsonPropertyName("translated")]
        public string Translated { get; set; } 

        [JsonPropertyName("text")]
        public string Text { get; set; } 

        [JsonPropertyName("translation")]
        public string Translation { get; set; } 
    }

}