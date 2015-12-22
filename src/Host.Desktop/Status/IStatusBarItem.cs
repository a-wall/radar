using System;
using System.ComponentModel;

namespace Host.Desktop.Status
{
    public interface IStatusBarItem
    {
        void ViewModel(Func<INotifyPropertyChanged> viewModelFactory);
    }
}
