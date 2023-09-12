using Newtonsoft.Json;

namespace CryptoApp.Models.DTOs
{
    public class CoinLinksDTO
    {
        [JsonProperty("homepage")]
        public List<string> Homepages { get; set; }
    }
}
