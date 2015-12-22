using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Host.Desktop.Dialog;

namespace Host.Desktop.Preference.ViewModel
{
    public class PreferencesViewModel : INotifyPropertyChanged, IDialogAware
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ICommand _okCommand;
        private ICommand _cancelCommand;
        private ICommand _closeCommand;
        private string _title;
        private ObservableCollection<PreferenceViewModel> _preferences;

        public void Add(IPreferenceRegister preferenceRegister)
        {
            var view = preferenceRegister.ViewFactory();
            view.DataContext = preferenceRegister.ViewModelFactory();
            var preferenceViewModel = new PreferenceViewModel
            {
                CommitCommand = preferenceRegister.Commit,
                RevertCommand = preferenceRegister.Revert,
                Icon = preferenceRegister.Icon,
                Title=preferenceRegister.Title,
                View = view
            };
            Preferences.Add(preferenceViewModel);
        }

        public PreferencesViewModel()
        {
            _title = "Preferences";
            _preferences = new ObservableCollection<PreferenceViewModel>();
        }

        public ICommand OkCommand
        {
            get { return _okCommand; }
            set
            {
                if (_okCommand != null && _okCommand == value) return;
                _okCommand = value;
                PropertyChanged.Raise(this, () => OkCommand);
            }
        }
        public ICommand CancelCommand
        {
            get { return _cancelCommand; }
            set
            {
                if (_cancelCommand != null && _cancelCommand == value) return;
                _cancelCommand = value;
                PropertyChanged.Raise(this, () => CancelCommand);
            }
        }
        public ICommand CloseCommand
        {
            get { return _closeCommand; }
            set
            {
                if (_closeCommand != null && _closeCommand == value) return;
                _closeCommand = value;
                PropertyChanged.Raise(this, () => CloseCommand);
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
        public ObservableCollection<PreferenceViewModel> Preferences
        {
            get { return _preferences; }
            set
            {
                if (_preferences != null && _preferences == value) return;
                _preferences = value;
                PropertyChanged.Raise(this, () => Preferences);
            }
        }
    }
}
