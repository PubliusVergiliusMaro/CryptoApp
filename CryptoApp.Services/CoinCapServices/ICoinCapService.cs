using CryptoApp.Common;
using CryptoApp.Models.DTOs;
using Newtonsoft.Json;

namespace CryptoApp.Services.CoinCapServices
{
    public interface ICoinCapService
    {
        Task<List<CoinDTO>> GetAllCoinsAsync();
        Task<CoinDTO> GetCoinByIdAsync(string coinId);
        Task<string> GetDataFromEndPoint(string url);
    }
}
