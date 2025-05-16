


using System.Globalization;

namespace Services.Services
{
    public static class LanguageManager
    {
        public static event EventHandler LanguageChanged;

        public static void SetLanguage(string cultureCode)
        {
            var cultureInfo = new CultureInfo(cultureCode);
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;

            LanguageChanged?.Invoke(typeof(LanguageManager), EventArgs.Empty);

            // Refresh all open windows
            //if (System.Net.Mime.MediaTypeNames.Application.Current != null)
            //{
            //    foreach (Window window in System.Net.Mime.MediaTypeNames.Application.Current.Windows)
            //    {
            //        window.InvalidateVisual(); // Force UI refresh
            //    }
            //}
        }
    }
}