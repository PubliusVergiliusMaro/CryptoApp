using Newtonsoft.Json;

namespace CryptoApp.Models.DTOs
{
    public class CoinDTO
    {
        public string Id { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        [JsonProperty("links")]
        public CoinLinksDTO Links { get; set; }
        [JsonProperty("image")]
        public CoinLogoDTO? Images { get; set; }
        [JsonProperty("market_cap_rank")]
        public decimal? CapRank { get; set; }
        [JsonProperty("max_supply")]
        public decimal? MaxSupply { get; set; }
        [JsonProperty("market_data")]
        public MarketDataDTO? MarketData { get; set; }
    }
}
