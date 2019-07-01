using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfLearningProject2
{

    public class MonitorPasswordProperty: BaseAttachedProperty<MonitorPasswordProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var passwordbox = (sender as PasswordBox);
            if (passwordbox == null)
                return;

            passwordbox.PasswordChanged -= Passwordbox_PasswordChanged;

            if ((bool)e.NewValue)
            {
                HasTextProperty.SetValue(passwordbox);
                passwordbox.PasswordChanged += Passwordbox_PasswordChanged;
            }
        }

        private void Passwordbox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            HasTextProperty.SetValue((PasswordBox)sender);
        }
    }
    public class HasTextProperty : BaseAttachedProperty<HasTextProperty, bool>
    {
        public static void SetValue(DependencyObject sender)
        {
            HasTextProperty.SetValue(sender, ((PasswordBox)sender).SecurePassword.Length > 0);
        }
    }
}
