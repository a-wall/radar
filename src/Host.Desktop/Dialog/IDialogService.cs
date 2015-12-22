namespace Host.Desktop.Dialog
{
    public interface IDialogService
    {
        IDialog Dialog(string name);
        IConfirmationDialog ConfirmationDialog(string name);
    }
}
