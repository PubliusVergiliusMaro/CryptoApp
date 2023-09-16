using Newtonsoft.Json;

namespace CryptoApp.Models.DTOs
{
    /// <summary>
    /// Using for getting a collection of CoinDTO from CoinCap
    /// </summary>
    public class CoinListDTO
    {
        [JsonProperty("data")]
        public List<CoinDTO> CoinList { get; set; }
    }
}
