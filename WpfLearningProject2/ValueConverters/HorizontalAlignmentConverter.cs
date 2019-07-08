using System;
using System.Globalization;
using System.Windows;
using WpfLearningProject2.ValueConverters;

namespace WpfLearningProject2
{
    public class HorizontalAlignmentConverter:BaseValueConverter<HorizontalAlignmentConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (HorizontalAlignment)value;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
