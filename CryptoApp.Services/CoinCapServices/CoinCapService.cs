using CryptoApp.Common;
using CryptoApp.Models.DTOs;
using Newtonsoft.Json;

namespace CryptoApp.Services.CoinCapServices
{
    public class CoinCapService : ICoinCapService
    {
        public async Task<List<CoinDTO>> GetAllCoinsAsync()
        {
            try
            {
                var response = await GetDataFromEndPoint(EndPoints.COINS_COINCAP);
                return JsonConvert.DeserializeObject<CoinListDTO>(response).CoinList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
