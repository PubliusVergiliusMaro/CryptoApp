using System;
using System.Windows;

namespace CryptoApp.Dekstop.Themes
{
    /// <summary>
    /// Service for changing program theme
    /// </summary>
    class ThemeService
    {
        public static void ChangeTheme(Uri themeUri)
        {
            ResourceDictionary theme = new ResourceDictionary()
            {
                Source = themeUri,
            };
            App.Current.Resources.Clear();
            App.Current.Resources.MergedDictionaries.Add(theme);
        }
    }
}
