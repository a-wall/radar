using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Host.Desktop.Theme.ViewModels
{
    public class ThemeViewModel: INotifyPropertyChanged, IEquatable<ThemeViewModel>
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _name;
        private ImageSource _image;

        public bool Equals(ThemeViewModel other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(_name, other._name);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj is ThemesViewModel && Equals((ThemeViewModel)obj);
        }

        public override int GetHashCode()
        {
            return _name?.GetHashCode() ?? 0;
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name == value) return;
                _name = value;
                PropertyChanged.Raise(this, () => Name);
            }
        }

        public ImageSource Image
        {
            get { return _image; }
            set
            {
                if (Equals(_image, value)) return;
                _image = value;
                PropertyChanged.Raise(this, () => Image);
            }
        }
    }
}
