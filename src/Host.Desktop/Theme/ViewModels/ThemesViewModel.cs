using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Host.Desktop.Theme.ViewModels
{
    public class ThemesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ThemeViewModel _theme;
        private ObservableCollection<ThemeViewModel> _themes;

        public ThemeViewModel Theme
        {
            get { return _theme; }
            set
            {
                if (_theme == value) return;
                _theme = value;
                PropertyChanged.Raise(this, () => Theme);
            }
        }

        public ObservableCollection<ThemeViewModel> Themes
        {
            get { return _themes; }
            set
            {
                if (_themes == value) return;
                _themes = value;
                PropertyChanged.Raise(this, () => Themes);
            }
        }
    }
}
