using System.ComponentModel;
using Host.Desktop;

namespace Radar.Ui.ViewModel
{
    public sealed class ConnectivityViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private bool _connected;

        public bool Connected
        {
            get
            {
                return _connected;
            }
            set
            {
                if (_connected == value) return;
                _connected = value;
                PropertyChanged.Raise(this, () => Connected);
            }
        }
    }
}
