using Newtonsoft.Json;

namespace CryptoApp.Models.DTOs
{
    public class CoinDTO
    {
        public string Id { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }

        // CoinCap
        public int? Rank { get; set; }
        public decimal? Supply { get; set; }
        public decimal? MarketCapUsd { get; set; }
        public decimal? VolumeUsd24Hr { get; set; }
        public decimal? PriceUsd { get; set; }
        public decimal? ChangePercent24Hr { get; set; }
        public decimal? vwap24Hr { get; set; }

        // CoinGecko
        [JsonProperty("links")]
        public CoinLinksDTO? Links { get; set; }
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
