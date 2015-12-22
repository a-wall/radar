namespace Host.Desktop.Dialog.Actions
{
    public interface IDialogAction
    {
        void ShowDialog(IDialogRegister dialog);

        ConfirmationResult ShowDialog(IConfirmationDialogRegister dialog);
    }
}
