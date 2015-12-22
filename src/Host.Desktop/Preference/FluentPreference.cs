using System;
using System.Windows;
using System.Windows.Input;
using Prism.Commands;

namespace Host.Desktop.Preference
{
    internal sealed class FluentPreference : IPreference, IPreferenceRegister
    {
        private readonly string _title;
        private readonly Action<IPreferenceRegister> _completionAction;
        private ICommand _commit;
        private ICommand _revert;
        private FrameworkElement _icon;
        private Func<FrameworkElement> _viewFactory;
        private Func<object> _viewModelFactory;

        public FluentPreference(string title, Action<IPreferenceRegister> completionAction)
        {
            _title = title;
            _completionAction = completionAction;
        }

        public IPreference Commit(Action commit)
        {
            _commit = new DelegateCommand(commit);
            return this;
        }

        public IPreference Revert(Action revert)
        {
            _revert = new DelegateCommand(revert);
            return this;
        }

        public IPreference Icon(FrameworkElement icon)
        {
            _icon = icon;
            return this;
        }

        public IPreference View(Func<FrameworkElement> viewFactory)
        {
            _viewFactory = viewFactory;
            return this;
        }

        public void ViewModel(Func<object> viewModelFactory)
        {
            _viewModelFactory = viewModelFactory;
            _completionAction(this);
        }

        ICommand IPreferenceRegister.Commit => _commit;

        ICommand IPreferenceRegister.Revert => _revert;

        public string Title => _title;

        FrameworkElement IPreferenceRegister.Icon => _icon;

        public Func<FrameworkElement> ViewFactory => _viewFactory;

        public Func<object> ViewModelFactory => _viewModelFactory;
    }
}