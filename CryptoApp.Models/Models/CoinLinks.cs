using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace CryptoApp.Models.Models
{
    public class CoinLinks
    {
        [JsonProperty("homepage")]
        public List<string> Homepages { get; set; }
    }
}
