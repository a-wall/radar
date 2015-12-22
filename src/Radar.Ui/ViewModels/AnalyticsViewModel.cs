using Host.Desktop;
using System.ComponentModel;

namespace Radar.Ui.ViewModel
{
    public class AnalyticsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _label;

        public string Label
        {
            get
            {
                return _label;
            }
            set
            {
                if (_label == value) return;
                _label = value;
                PropertyChanged.Raise(this, () => Label);
            }
        }
    }
}
