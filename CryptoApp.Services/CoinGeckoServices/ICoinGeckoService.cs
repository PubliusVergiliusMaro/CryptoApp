using CryptoApp.Models.DTOs;

namespace CryptoApp.Services.CoinGeckoServices
{
    public interface ICoinGeckoService
    {
        event EventHandler<string> ErrorOccurred;
        Task<List<CoinDTO>> GetAllCoinsAsync();
        Task<CoinDTO> GetCoinByIdAsync(string coinId);
    }
}
