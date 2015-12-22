using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace Host.Desktop.Preference.ViewModel
{
    public sealed class PreferenceViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _title;
        private FrameworkElement _icon;
        private FrameworkElement _view;
        private ICommand _commitCommand;
        private ICommand _revertCommand;


        public ICommand CommitCommand
        {
            get { return _commitCommand; }
            set
            {
                if (_commitCommand != null && _commitCommand == value) return;
                _commitCommand = value;
                PropertyChanged.Raise(this, ()=> CommitCommand);
            }
        }

        public ICommand RevertCommand
        {
            get { return _revertCommand; }
            set
            {
                if (_revertCommand != null && _revertCommand == value) return;
                _revertCommand = value;
                PropertyChanged.Raise(this, () => RevertCommand);
            }
        }

        public string Title
        {
            get { return _title; }
            set
            {
                if (_title != null && _title == value) return;
                _title = value;
                PropertyChanged.Raise(this, () => Title);
            }
        }

        public FrameworkElement Icon
        {
            get { return _icon; }
            set
            {
                if (_icon == value) return;
                _icon = value;
                PropertyChanged.Raise(this, () => Icon);
            }
        }

        public FrameworkElement View
        {
            get { return _view; }
            set
            {
                if (_view == value) return;
                _view = value;
                PropertyChanged.Raise(this, () => View);
            }
        }
    }
}
