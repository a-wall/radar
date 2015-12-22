using System;
using System.ComponentModel;
using System.Windows;

namespace Host.Desktop.Status
{
    public interface IStatusBarItemRegister
    {
        Func<FrameworkElement> ViewFactory { get; }
        Func<INotifyPropertyChanged> ViewModelFactory { get; }
    }
}
