namespace Host.Desktop.Dialog
{
    public interface IConfirmationDialog
    {
        IConfirmationDialog Message(string message);
        IConfirmationDialog Owner(System.Windows.Window owner);
        IConfirmationDialog Severity(ConfirmationSeverity severity);
        IConfirmationDialog OkButton();
        IConfirmationDialog CancelButton();
        IConfirmationDialog YesButton();
        IConfirmationDialog NoButton();
        IConfirmationDialog DefaultResult(ConfirmationResult defaultResult);
        ConfirmationResult Show();
    }
}
