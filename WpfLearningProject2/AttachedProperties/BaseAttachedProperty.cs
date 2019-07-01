using System;
using System.Windows;

namespace WpfLearningProject2
{
    public abstract class BaseAttachedProperty<Parent, Property>
        where Parent : BaseAttachedProperty<Parent, Property>, new()
    {
        #region Public Events
        public event Action<DependencyObject, DependencyPropertyChangedEventArgs> ValueChanged = (sender, e) => { };
        #endregion

        #region public properties

        public static Parent Instance { get; set; } = new Parent();


        #endregion

        #region Attached Properties Definitions
        public static readonly DependencyProperty ValueProperty = DependencyProperty.RegisterAttached("Value", typeof(Property), typeof(BaseAttachedProperty<Parent, Property>), new PropertyMetadata(new PropertyChangedCallback(OnValuePropertyChanged)));

        private static void OnValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Instance.OnValueChanged(d, e);

            Instance.ValueChanged(d, e);
        }

        public static Property GetValue(DependencyObject d) => (Property)d.GetValue(ValueProperty);
        public static void SetValue(DependencyObject d, Property value) => d.SetValue(ValueProperty, value);

        #endregion

        #region Event Methods
        public virtual void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e){ }
        #endregion
    }
}
