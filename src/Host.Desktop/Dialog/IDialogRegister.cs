using System;
using System.ComponentModel;
using System.Windows;
using Host.Desktop.Window;

namespace Host.Desktop.Dialog
{
    public interface IDialogRegister
    {
        string Name { get; }
        System.Windows.Window Owner { get; }
        Func<FrameworkElement> ViewFactory { get; }
        Func<IObservable<WindowEvent>, INotifyPropertyChanged> ViewModelFactory { get; }
        bool AllowResize { get; }
        Size? Size { get; }
    }
}
