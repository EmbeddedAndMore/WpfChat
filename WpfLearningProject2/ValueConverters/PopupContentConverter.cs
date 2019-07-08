
using System;
using System.Globalization;
using System.Windows;
using WpfLearningProject2.Core;
using WpfLearningProject2.ValueConverters;

namespace WpfLearningProject2
{
    public class PopupContentConverter : BaseValueConverter<PopupContentConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is ChatAttachmentPopupMenuViewModel basPopup)
            {
                return new VerticalMenu() { DataContext = basPopup.Content };
            }
            return null;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
