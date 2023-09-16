using CryptoApp.Common;
using CryptoApp.Models.DTOs;
using Newtonsoft.Json;

namespace CryptoApp.Services.CoinGeckoServices
{
    public class CoinGeckoService : ICoinGeckoService
    {
        /// <summary>
        /// Get all coins from CoinGecko
        /// </summary>
        /// <returns></returns>
        public async Task<List<CoinDTO>> GetAllCoinsAsync()
        {
            var response = await GetDataFromEndPoint(EndPoints.COINS_COINGECKO);
            return JsonConvert.DeserializeObject<List<CoinDTO>>(response);
        }
        /// <summary>
        /// Get coin by Id from CoinGecko 
        /// </summary>
        /// <param name="coinId"></param>
        /// <returns></returns>
        public async Task<CoinDTO> GetCoinByIdAsync(string coinId)
        {
            var response = await GetDataFromEndPoint(EndPoints.COIN_COINGECKO + coinId);
            return JsonConvert.DeserializeObject<CoinDTO>(response);
        }
        private async Task<string> GetDataFromEndPoint(string url)
        {
            try
            {
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }
            catch (System.Net.Http.HttpRequestException ex)
            {
                throw new System.Net.Http.HttpRequestException(ex.Message);
            }
        }
       
    }
}
