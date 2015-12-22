namespace Host.Desktop.Dialog
{
    public interface IConfirmationDialogRegister
    {
        string Title { get; }
        string Message { get; }
        System.Windows.Window Owner { get; }
        bool OkButton { get; }
        bool CancelButton { get; }
        bool YesButton { get; }
        bool NoButton { get; }
        ConfirmationSeverity Severity { get; }
        ConfirmationResult DefaultResult { get; }
    }
}
