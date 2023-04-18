using System.Windows;

namespace LockBox.Data.Helpers;

public static class PasswordHelper
{
    public static readonly DependencyProperty AttachProperty = DependencyProperty.RegisterAttached("Attach", typeof(object), typeof(PasswordHelper), new PropertyMetadata(default(object)));
    public static readonly DependencyProperty PasswordProperty = DependencyProperty.RegisterAttached("Password", typeof(object), typeof(PasswordHelper), new PropertyMetadata(default(object)));

    public static object GetAttach(UIElement element)
    {
        return element.GetValue(AttachProperty);
    }

    public static void SetAttach(UIElement element, object value)
    {
        element.SetValue(AttachProperty, value);
    }

    public static object GetPassword(UIElement element)
    {
        return element.GetValue(PasswordProperty);
    }

    public static void SetPassword(UIElement element, object value)
    {
        element.SetValue(PasswordProperty, value);
    }
}