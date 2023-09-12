using CryptoApp.Models.Models;

namespace CryptoApp.Services.CoinGeckoServices
{
    public interface ICoinGeckoService
    {
        Task<List<Coin>> GetAllCoinsAsync();
        Task<Coin> GetCoinByIdAsync(string coinId);
    }
}
