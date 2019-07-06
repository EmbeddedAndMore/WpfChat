using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfLearningProject2
{

 
    public class IsFocucedProperty : BaseAttachedProperty<IsFocucedProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if (!(sender is Control control))
                return;

            control.Loaded += (ss, ee) => control.Focus();
        }
    }
}
