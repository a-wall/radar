using System.Windows.Input;

namespace Host.Desktop.Core
{
    public interface IShell
    {
        void Show();
        void Close();
        void AddKeyBinding(ICommand command, KeyGesture keyGesture);
    }
}
