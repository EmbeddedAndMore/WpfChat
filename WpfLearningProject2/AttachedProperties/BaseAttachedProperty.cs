using System;
using System.Windows;

namespace WpfLearningProject2
{
    public abstract class BaseAttachedProperty<Parent, Property>
        where Parent : new()
    {
        #region Public Events
        public event Action<DependencyObject, DependencyPropertyChangedEventArgs> ValueChanged = (sender, e) => { };

        public event Action<DependencyObject, object> ValueUpdated = (sender, value) => { };
        
        #endregion

        #region public properties

        public static Parent Instance { get; set; } = new Parent();


        #endregion

        #region Attached Properties Definitions
        public static readonly DependencyProperty ValueProperty = 
            DependencyProperty.RegisterAttached("Value", 
                typeof(Property), 
                typeof(BaseAttachedProperty<Parent, Property>), 
                new UIPropertyMetadata(default(Property),new PropertyChangedCallback(OnValuePropertyChanged), new CoerceValueCallback(OnValuePropertyUpdated)));

        private static object OnValuePropertyUpdated(DependencyObject d, object baseValue)
        {
            (Instance as BaseAttachedProperty<Parent, Property>)?.OnValueUpdated(d, baseValue);

           (Instance as BaseAttachedProperty<Parent, Property>)?.OnValueUpdated(d, baseValue);

            return baseValue;
        }

        private static void OnValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (Instance as BaseAttachedProperty<Parent, Property>)?.OnValueChanged(d, e);

            (Instance as BaseAttachedProperty<Parent, Property>)?.ValueChanged(d, e);
        }

        public static Property GetValue(DependencyObject d) => (Property)d.GetValue(ValueProperty);
        public static void SetValue(DependencyObject d, Property value) => d.SetValue(ValueProperty, value);

        #endregion

        #region Event Methods
        public virtual void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e){ }

        public virtual void OnValueUpdated(DependencyObject sender, object value) { }
        #endregion
    }
}
