using System.Linq;
using Host.Desktop.Preference.ViewModel;
using Microsoft.Practices.ObjectBuilder2;
using Prism.Commands;

namespace Host.Desktop.Preference.ViewController
{
    public sealed class PreferencesViewController
    {
        public PreferencesViewController()
        {
            ViewModel = new PreferencesViewModel();
            ViewModel.OkCommand = new DelegateCommand(
                () =>
                {
                    ViewModel.Preferences.ToArray().ForEach(p =>
                    {
                        if (p.CommitCommand.CanExecute(null))
                            p.CommitCommand.Execute(null);
                    });
                    if (ViewModel.CloseCommand.CanExecute(null))
                        ViewModel.CloseCommand.Execute(null);
                });
            ViewModel.CancelCommand = new DelegateCommand(
                () =>
                {
                    ViewModel.Preferences.ToArray().ForEach(p =>
                    {
                        if (p.RevertCommand.CanExecute(null))
                            p.RevertCommand.Execute(null);
                    });
                    if (ViewModel.CloseCommand.CanExecute(null))
                        ViewModel.CloseCommand.Execute(null);
                });
        }

        public PreferencesViewModel ViewModel { get; }
    }
}
