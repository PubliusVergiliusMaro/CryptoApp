using Newtonsoft.Json;

namespace CryptoApp.Models.DTOs
{
    public class CoinListDTO
    {
        [JsonProperty("data")]
        public List<CoinDTO> CoinList { get; set; }
    }
}
