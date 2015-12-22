using System;
using System.Windows;
using System.Windows.Input;

namespace Host.Desktop.Preference
{
    public interface IPreferenceRegister
    {
        ICommand Commit { get; }
        ICommand Revert { get; }
        string Title { get; }
        FrameworkElement Icon { get; }
        Func<FrameworkElement> ViewFactory { get; }
        Func<object> ViewModelFactory { get; }
    }
}
