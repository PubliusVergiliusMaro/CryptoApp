using Newtonsoft.Json;

namespace CryptoApp.Models.DTOs
{
    public class CoinLogoDTO
    {
        [JsonProperty("large")]
        public string Image { get; set; }
    }
}
