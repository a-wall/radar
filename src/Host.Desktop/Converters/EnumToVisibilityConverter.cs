using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Host.Desktop.Converters
{
    [ValueConversion(typeof(Enum), typeof(Visibility))]
    public sealed class EnumToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || Enum.IsDefined(value.GetType(), value) == false)
                return DependencyProperty.UnsetValue;

            if (parameter.Equals(value))
                return Visibility.Visible;

            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.Equals(Visibility.Collapsed))
                return Activator.CreateInstance(targetType);

            return parameter;
        }
    }
}
