using CryptoApp.Common;
using CryptoApp.Models.DTOs;
using Newtonsoft.Json;

namespace CryptoApp.Services.CoinGeckoServices
{
    public class CoinGeckoService : ICoinGeckoService
    {
        public async Task<List<CoinDTO>> GetAllCoinsAsync()
        {
            var response = await GetDataFromEndPoint(EndPoints.COINS);
            return JsonConvert.DeserializeObject<List<CoinDTO>>(response);
        }

        public async Task<CoinDTO> GetCoinByIdAsync(string coinId)
        {
            var response = await GetDataFromEndPoint(EndPoints.COIN + coinId);
            return JsonConvert.DeserializeObject<CoinDTO>(response);
        }

        public async Task<string> GetDataFromEndPoint(string url)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        }
    }
}
