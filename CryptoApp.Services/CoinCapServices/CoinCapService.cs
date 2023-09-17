using CryptoApp.Common;
using CryptoApp.Models.DTOs;
using Newtonsoft.Json;

namespace CryptoApp.Services.CoinCapServices
{
    public class CoinCapService : ICoinCapService
    {
        public event EventHandler<string> ErrorOccurred;
        /// <summary>
        /// Get all coins from CoinCap
        /// </summary>
        /// <returns></returns>
        public async Task<List<CoinDTO>> GetAllCoinsAsync()
        {
            var response = await GetDataFromEndPoint(EndPoints.COINS_COINCAP);
            return JsonConvert.DeserializeObject<CoinListDTO>(response).CoinList;
        }
        /// <summary>
        /// Get coin by Id from CoinCap 
        /// </summary>
        /// <param name="coinId"></param>
        /// <returns></returns>
        public async Task<CoinDTO> GetCoinByIdAsync(string coinId)
        {
            var response = await GetDataFromEndPoint(EndPoints.COIN_COINCAP + coinId);
            var answer = JsonConvert.DeserializeObject<CoinDTOCoinCap>(response).Data;
            return answer;
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
                ErrorOccurred?.Invoke(this, ex.Message);
                return null;
            }
        }
    }
}
