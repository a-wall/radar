using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace Host.Desktop.Menu
{
    public interface IMenu
    {
        IMenu Menu(string menu);
        IMenu Group(string group);
        IMenu Bold();
        IMenu Style(string style);
        IMenu View(Func<FrameworkElement> viewFactory);
        IMenu ViewModel(Func<INotifyPropertyChanged> viewModelFactory);
        void Command(ICommand command);
        void Command(ICommand command, object commandParameter);
        void Command(Action command);
    }
}
