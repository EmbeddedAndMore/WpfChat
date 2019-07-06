
using System;
using System.Globalization;
using System.Windows;
using WpfLearningProject2.ValueConverters;

namespace WpfLearningProject2
{
    public class TimeToDisplayTimeConverter : BaseValueConverter<TimeToDisplayTimeConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var time = (DateTimeOffset)value;

            if (time.Date == DateTimeOffset.UtcNow.Date)
                return time.ToLocalTime().ToString("HH:mm");

            return time.ToLocalTime().ToString("HH:mm, MMM yyyy");
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
