
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using WpfLearningProject2.Core;
using WpfLearningProject2.ValueConverters;

namespace WpfLearningProject2
{
    public class MenuItemVisibilityConverter : BaseValueConverter<MenuItemVisibilityConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter == null)
                return Visibility.Collapsed;

            if (!Enum.TryParse(parameter as string, out MenuItemType type))
                return Visibility.Collapsed;

            if (((MenuItemType)value) == type)
                return Visibility.Visible;
            else
                return Visibility.Collapsed;

        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
