﻿namespace CryptoApp.Common
{
    public class EndPoints
    {
        /// <summary>
        /// Get all supported coins
        /// </summary>
        public const string COINS = @"https://api.coingecko.com/api/v3/coins/list";
        /// <summary>
        /// Get Coin adding to this Id: EndPoints.COIN + coin`s id
        /// </summary>
        public const string COIN = @"https://api.coingecko.com/api/v3/coins/";
    }
}
