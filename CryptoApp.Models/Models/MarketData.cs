using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace CryptoApp.Models.Models
{
    public class MarketData
    {
        [JsonProperty("current_price")]
        public CoinPrice CurrentPrice { get; set; }
        [JsonProperty("total_volume")]
        public CoinPrice TotalVolume { get; set; }
        [JsonProperty("high_24h")]
        public CoinPrice High { get; set; }
        [JsonProperty("low_24h")]
        public CoinPrice Low { get; set; }
        [JsonProperty("price_change_24h")]
        public decimal PriceChange { get; set; }
        [JsonProperty("price_change_percentage_24h")]
        public decimal PriceChangePercentage { get; set; }
        [JsonProperty("max_supply")]
        public decimal? MaxSupply { get; set; }
        public CoinPrice? Ath { get; set; }
        [JsonProperty("ath_change_percentage")]
        public CoinPrice? AthChange { get; set; }
        [JsonProperty("ath_date")]
        public CoinPrice? AthDate { get; set; }
        [JsonProperty("atl")]
        public CoinPrice? Atl { get; set; }
        [JsonProperty("atl_change_percentage")]
        public CoinPrice? AtlChange { get; set; }
        [JsonProperty("atl_data")]
        public CoinPrice? AtlDate { get; set; }
        [JsonProperty("market_cap")]
        public CoinPrice? MarketCap { get; set; }
        [JsonProperty("price_change_percentage_7d")]
        public decimal PriceChange7d { get; set; }
        [JsonProperty("price_change_percentage_14d")]
        public decimal? PriceChange14d { get; set; }
        [JsonProperty("market_cap_change_percentage_24h_in_currency")]
        public CoinPrice? PriceCapChange { get; set; }
        [JsonProperty("last_updated")]
        public DateTime? LastUpdated { get; set; }
    }
}
