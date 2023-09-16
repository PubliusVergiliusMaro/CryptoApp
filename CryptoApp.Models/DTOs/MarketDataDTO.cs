using Newtonsoft.Json;

namespace CryptoApp.Models.DTOs
{
    public class MarketDataDTO
    {
        [JsonProperty("current_price")]
        public Dictionary<string, decimal?>? CurrentPrice { get; set; }
        [JsonProperty("total_volume")]
        public Dictionary<string, decimal?>? TotalVolume { get; set; }
        [JsonProperty("high_24h")]
        public Dictionary<string, decimal?>?High { get; set; }
        [JsonProperty("low_24h")]
        public Dictionary<string, decimal?>? Low { get; set; }
        [JsonProperty("price_change_24h")]
        public decimal? PriceChange { get; set; }
        [JsonProperty("price_change_percentage_24h")]
        public decimal? PriceChangePercentage { get; set; }
        [JsonProperty("max_supply")]
        public decimal? MaxSupply { get; set; }
        public Dictionary<string, decimal?>? Ath { get; set; }
        [JsonProperty("ath_change_percentage")]
        public Dictionary<string, decimal?>? AthChange { get; set; }
        [JsonProperty("ath_date")]
        public Dictionary<string, DateTime?>? AthDate { get; set; }
        [JsonProperty("atl")]
        public Dictionary<string, decimal?>? Atl { get; set; }
        [JsonProperty("atl_change_percentage")]
        public Dictionary<string, decimal?>? AtlChange { get; set; }
        [JsonProperty("atl_data")]
        public Dictionary<string, DateTime?>? AtlDate { get; set; }
        [JsonProperty("market_cap")]
        public Dictionary<string, decimal?>? MarketCap { get; set; }
        [JsonProperty("price_change_percentage_7d")]
        public decimal? PriceChange7d { get; set; }
        [JsonProperty("price_change_percentage_14d")]
        public decimal? PriceChange14d { get; set; }
        [JsonProperty("market_cap_change_percentage_24h_in_currency")]
        public Dictionary<string, decimal?>? PriceCapChange { get; set; }
        [JsonProperty("last_updated")]
        public DateTime? LastUpdated { get; set; }
    }
}
