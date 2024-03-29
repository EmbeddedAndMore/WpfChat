﻿
using Ninject;
using System;
using System.Diagnostics;
using System.Globalization;
using WpfLearningProject2.Core.DataModels;
using WpfLearningProject2.Core;
using WpfLearningProject2.Core.ViewModel;
using WpfLearningProject2.ValueConverters;

namespace WpfLearningProject2
{
    public class IoCConverter : BaseValueConverter<IoCConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch((string)parameter)
            {
                case nameof(ApplicationViewModel):
                    return IoC.Get<ApplicationViewModel>();

                

                default:
                    Debugger.Break();
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
