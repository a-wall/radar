using System;
using System.ComponentModel;
using System.Windows;
using Host.Desktop.Window;

namespace Host.Desktop.Dialog
{
    public interface IDialog
    {
        IDialog Owner(System.Windows.Window owner);
        IDialog View(Func<FrameworkElement> viewFactory);
        IDialog ViewModel(Func<IObservable<WindowEvent>, INotifyPropertyChanged> viewModelFactory);
        IDialog Size(double width, double height);
        void Show();
    }
}
