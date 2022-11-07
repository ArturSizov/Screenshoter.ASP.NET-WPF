using Sceenshoter.ScreenshoterApplication.Interaction.Queries.GetScreensotList;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Screenshoter.WPF.UI.Converters
{
    public class IsEnabledButtonConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string screenshot)
            {
                if (screenshot != null) return true;
                else return false;
            }
            else return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
