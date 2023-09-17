using CryptoApp.Models.DTOs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace CryptoApp.Dekstop.ViewModels
{
    /// <summary>
    /// ViewModel responsible for presenting CoinDTO in a convenient format. 
    /// </summary>
    public class CoinViewModel : ViewModelBase
    {
        public CoinViewModel(CoinDTO coin)
        {
            _coin = coin;
        }
        public string Id => _coin.Id;
        public string Symbol => _coin.Symbol;
        public string Name => _coin.Name;
        public decimal? CapRank => _coin.CapRank;
        public ICollection<string>? Homepages => _coin.Links.Homepages;
        public ImageSource? Logo => GetImage(_coin.Images.Image);
        public Dictionary<string, decimal?>? CurrentPrice => _coin.MarketData.CurrentPrice;
        public Dictionary<string, decimal?>? TotalVolume => _coin.MarketData.TotalVolume;
        public Dictionary<string, decimal?>? High => _coin.MarketData.High;
        public Dictionary<string, decimal?>? Low => _coin.MarketData.Low;
        public decimal? PriceChange => _coin.MarketData.PriceChange;
        public decimal? PriceChangePercentage => _coin.MarketData.PriceChangePercentage;
        public decimal? MaxSupply => _coin.MarketData.MaxSupply;
        public Dictionary<string, decimal?>? Ath => _coin.MarketData.Ath;
        public Dictionary<string, decimal?>? AthChange => _coin.MarketData.AthChange;
        public Dictionary<string, DateTime?>? AthDate => _coin.MarketData.AthDate;
        public Dictionary<string, decimal?>? Atl => _coin.MarketData.Atl;
        public Dictionary<string, decimal?>? AtlChange => _coin.MarketData.AtlChange;
        public Dictionary<string, DateTime?>? AtlDate => _coin.MarketData.AtlDate;
        public Dictionary<string, decimal?>? MarketCap => _coin.MarketData.MarketCap;
        public decimal? PriceChange7d => _coin.MarketData.PriceChange7d;
        public decimal? PriceChange14d => _coin.MarketData.PriceChange14d;
        public Dictionary<string, decimal?>? PriceCapChange => _coin.MarketData.PriceCapChange;
        public DateTime? LastUpdated => _coin.MarketData.LastUpdated;
        private readonly CoinDTO _coin;
        /// <summary>
        /// Responsible for getting image from url and returning in ImageSource format
        /// </summary>
        /// <param name="imageUrl">url of image</param>
        /// <returns>Image in ImageSource format</returns>
        private ImageSource GetImage(string imageUrl)
        {
            using (WebClient wc = new WebClient())
            {
                byte[] data = wc.DownloadData(imageUrl);
                using (var stream = new MemoryStream(data))
                {
                    var bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.StreamSource = stream;
                    bitmapImage.EndInit();
                    ImageSource img = bitmapImage;
                    return img;
                }
            }
        }
    }
}
