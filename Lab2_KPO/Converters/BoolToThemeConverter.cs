using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Lab2_KPO.Converters;

public class BoolToThemeConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        bool isBoysMode = (bool)value;
        string[] resources = ((string)parameter).Split('|');
            
        string resourceKey = isBoysMode ? resources[0] : resources[1];
        return Application.Current.Resources[resourceKey];
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return DependencyProperty.UnsetValue;
    }
}