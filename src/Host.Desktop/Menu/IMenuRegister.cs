using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace Host.Desktop.Menu
{
    public interface IMenuRegister
    {
        string Name { get; }
        string Group { get; }
        FontWeight FontWeight { get; }
        FrameworkElement Icon { get; }
        bool Checkable { get; }
        ICommand Command { get; }
        object CommandParameter { get; }
        string Style { get; }
        IMenuRegister SubMenu { get; }
        IMenuRegister ParentMenu { get; }
        FlowDirection FlowDirection { get; }
        Func<INotifyPropertyChanged, FrameworkElement> ViewFactory { get; }
        Func<INotifyPropertyChanged> ViewModelFactory { get; }
        KeyGesture Gesture { get; }
    }
}
