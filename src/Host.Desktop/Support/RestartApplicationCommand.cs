using System;
using System.Windows;
using System.Windows.Input;

namespace Host.Desktop.Support
{
    public sealed class RestartApplicationCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Application.Current.Shutdown();
        }

        public event EventHandler CanExecuteChanged;
    }
}
