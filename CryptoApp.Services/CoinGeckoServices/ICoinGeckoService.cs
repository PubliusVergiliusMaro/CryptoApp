using CryptoApp.Models.DTOs;

namespace CryptoApp.Services.CoinGeckoServices
{
    public interface ICoinGeckoService
    {
        Task<List<CoinDTO>> GetAllCoinsAsync();
        Task<CoinDTO> GetCoinByIdAsync(string coinId);
    }
}
