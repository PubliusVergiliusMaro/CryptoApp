using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace CryptoApp.Models.Models
{
    public class CoinLogo
    {
        [JsonProperty("large")]
        public string Image { get; set; }
    }
}
