using Sceenshoter.ScreenshoterApplication.Interaction.Queries.GetScreensotList;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Data;

namespace Screenshoter.WPF.UI.Converters
{
    public class VisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                var scrennshots = value as ObservableCollection<ScreenshotLookupDto>;

                if (scrennshots?.Count != 0) return "Visible";

                else return "Collapsed";
            }
            else return "Collapsed";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
