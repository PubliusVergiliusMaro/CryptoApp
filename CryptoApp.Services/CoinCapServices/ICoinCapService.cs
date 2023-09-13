using CryptoApp.Models.DTOs;

namespace CryptoApp.Services.CoinCapServices
{
    public interface ICoinCapService
    {
        Task<List<CoinDTO>> GetAllCoinsAsync();
    }
}
