// Add this using directive at the top of your file:
using System.Globalization;
using System.Windows; // For Application and Window

namespace Services.Services
{
    public static class LanguageManager
    {
        // Make the event nullable to fix CS8618
        public static event EventHandler? LanguageChanged;

        public static void SetLanguage(string cultureCode)
        {
            var cultureInfo = new CultureInfo(cultureCode);
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;

            LanguageChanged?.Invoke(typeof(LanguageManager), EventArgs.Empty);

            // Refresh all open windows
            //if (Application.Current != null)
            //{
            //    foreach (Window window in Application.Current.Windows)
            //    {
            //        window.InvalidateVisual(); // Force UI refresh
            //    }
            //}
        }
    }
}
