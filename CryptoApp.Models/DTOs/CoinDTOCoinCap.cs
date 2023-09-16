using Newtonsoft.Json;

namespace CryptoApp.Models.DTOs
{
    /// <summary>
    /// Using for getting single CoinDTO from CoinCap
    /// </summary>
    public class CoinDTOCoinCap
    {
        [JsonProperty("data")]
        public CoinDTO Data { get; set; }
    }
}
