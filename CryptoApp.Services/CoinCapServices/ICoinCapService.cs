using CryptoApp.Common;
using CryptoApp.Models.DTOs;
using Newtonsoft.Json;

namespace CryptoApp.Services.CoinCapServices
{
    public interface ICoinCapService
    {
        event EventHandler<string> ErrorOccurred;
        Task<List<CoinDTO>> GetAllCoinsAsync();
        Task<CoinDTO> GetCoinByIdAsync(string coinId);
    }
}
