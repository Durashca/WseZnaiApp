using Microsoft.Maui.Controls;
using Microsoft.Maui.Handlers;

namespace WseZnai
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            LoadLocalWebsite();
        }

        private void LoadLocalWebsite()
        {
            // Включаем JavaScript для Android
#if ANDROID
            EnableJavaScript();
            // Загружаем index.html из папки assets (путь относительно Resources/Raw)
            webView.Source = "file:///android_asset/www/site/index.html";
#else
            // Для других платформ можно добавить альтернативный метод,
            // но в вашем случае приложение только для Android.
            webView.Source = "https://example.com"; // или оставьте пустым
#endif
        }

        private void EnableJavaScript()
        {
#if ANDROID
            WebViewHandler.Mapper.AppendToMapping("JavaScriptEnabled", (handler, view) =>
            {
                if (handler.PlatformView is Android.Webkit.WebView webView)
                {
                    webView.Settings.JavaScriptEnabled = true;
                    // Дополнительно: разрешаем доступ к файлам из asset
                    webView.Settings.AllowFileAccess = true;
                    webView.Settings.AllowFileAccessFromFileURLs = true;
                    webView.Settings.AllowUniversalAccessFromFileURLs = true;
                }
            });
#endif
        }
    }
}