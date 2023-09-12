using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace CryptoApp.Models.Models
{
    public class Coin
    {
        public string Id { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        [JsonProperty("links")]
        public CoinLinks Links { get; set; }
        [JsonProperty("image")]
        public CoinLogo? Images { get; set; }
        [JsonProperty("market_cap_rank")]
        public decimal? CapRank { get; set; }
        [JsonProperty("max_supply")]
        public decimal? MaxSupply { get; set;}
        [JsonProperty("market_data")]
        public MarketData? MarketData { get; set; }
    }
}
