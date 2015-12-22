using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Host.Desktop.Preference
{
    public interface IPreference
    {
        IPreference Commit(Action commit);
        IPreference Revert(Action revert);
        IPreference Icon(FrameworkElement icon);
        IPreference View(Func<FrameworkElement> viewFactory);
        void ViewModel(Func<object> viewModelFactory);
    }
}
