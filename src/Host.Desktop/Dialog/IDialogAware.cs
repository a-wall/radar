using System.Windows.Input;

namespace Host.Desktop.Dialog
{
    public interface IDialogAware
    {
        ICommand CloseCommand { get; set; }
        string Title { get; set; }
    }
}
