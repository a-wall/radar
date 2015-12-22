using System;
using System.ComponentModel;
using System.Windows;

namespace Host.Desktop.Status
{
    public sealed class FluentStatusBarItem : IStatusBarItem, IStatusBarItemRegister
    {
        private readonly Func<FrameworkElement> _viewFactory;
        private readonly Action<IStatusBarItemRegister> _completionAction;
        private Func<INotifyPropertyChanged> _viewModelFactory;

        public FluentStatusBarItem(Func<FrameworkElement> viewFactory, Action<IStatusBarItemRegister> completionAction)
        {
            _viewFactory = viewFactory;
            _completionAction = completionAction;
        }

        public void ViewModel(Func<INotifyPropertyChanged> viewModelFactory)
        {
            _viewModelFactory = viewModelFactory;
            _completionAction(this);
        }

        public Func<FrameworkElement> ViewFactory { get { return _viewFactory;} }
        public Func<INotifyPropertyChanged> ViewModelFactory { get {return _viewModelFactory;} }
    }
}
