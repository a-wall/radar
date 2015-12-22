using Host.Desktop.Dialog.Actions;

namespace Host.Desktop.Dialog
{
    public sealed class FluentDialogService : IDialogService
    {
        private readonly IDialogAction _dialogAction;

        public FluentDialogService(IDialogAction dialogAction)
        {
            _dialogAction = dialogAction;
        }

        public IDialog Dialog(string name)
        {
            return new FluentDialog(name, _dialogAction.ShowDialog);
        }

        public IConfirmationDialog ConfirmationDialog(string name)
        {
            return new FluentConfirmationDialog(name, _dialogAction.ShowDialog);
        }
    }
}