

using System;
using System.Windows;

namespace WpfLearningProject2
{
    public abstract class AnimateBaseProperty<Parent> :BaseAttachedProperty<Parent, bool>
            where Parent:BaseAttachedProperty<Parent, bool>, new()
    {
        public bool IsFirstRun { get; set; } = true;

        public override void OnValueUpdated(DependencyObject sender, object value)
        {
            if (!(sender is FrameworkElement element))
                return;

            if (sender.GetValue(ValueProperty) == value && !IsFirstRun)
                return;

            if(IsFirstRun)
            {
                RoutedEventHandler onLoaded = null;
                onLoaded = (ss, ee) =>
                {
                    element.Loaded -= onLoaded;

                    DoAnimation(element, (bool)value);

                    IsFirstRun = false;
                };

                element.Loaded += onLoaded;

            }else
                DoAnimation(element, (bool)value);  

        }

        protected virtual void DoAnimation(FrameworkElement element, bool value)
        {
            
        }
    }

    /// <summary>
    /// Animates framework element ,sliding it in from left to show
    /// and slide out to the left to hide
    /// </summary>
    public class AnimationSlideInFromLeftProperty : AnimateBaseProperty<AnimationSlideInFromLeftProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value)
        {
            if (value)
            {
                // Animate in
                await element.SlideAndFadeInFromLeftAsync(IsFirstRun ? 0 : 0.3f, keepMargin: false);
            }
            else
                await element.SlideAndFadeOutToLeftAsync(IsFirstRun ? 0 : 0.3f, keepMargin: false);
        }
    }
}
