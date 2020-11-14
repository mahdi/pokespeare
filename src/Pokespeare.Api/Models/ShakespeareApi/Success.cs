using System.Text.Json.Serialization; 
namespace Pokespeare.Api.Models.ShakespeareApi{ 

    public class Success    {
        [JsonPropertyName("total")]
        public int Total { get; set; } 
    }

}