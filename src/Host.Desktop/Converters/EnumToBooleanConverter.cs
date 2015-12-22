using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Host.Desktop.Converters
{
    [ValueConversion(typeof(Enum), typeof(bool))]
    public sealed class EnumToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || Enum.IsDefined(value.GetType(), value) == false)
                return DependencyProperty.UnsetValue;

            return parameter.Equals(value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.Equals(false))
                return Activator.CreateInstance(targetType);

            return parameter;
        }
    }
}
