namespace CryptoApp.Common
{
    public class EndPoints
    {
        /// <summary>
        /// Get all supported coins from CoinGecko
        /// </summary>
        public const string COINS_COINGECKO = @"https://api.coingecko.com/api/v3/coins/list";
        /// <summary>
        /// Get Coin adding to this Id: EndPoints.COIN_COINGECKO + coin`s id
        /// </summary>
        public const string COIN_COINGECKO = @"https://api.coingecko.com/api/v3/coins/";
        /// <summary>
        /// Get 100 coins from CoinCap
        /// </summary>
        public const string COINS_COINCAP = @"https://api.coincap.io/v2/assets";
        /// <summary>
        /// Get Coin adding to this Id: EndPoints.COIN_COINCAP + coin`s id
        /// </summary>
        public const string COIN_COINCAP = @"https://api.coincap.io/v2/assets/";
    }
}
