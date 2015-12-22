namespace Host.Desktop.Dialog.ViewModels
{
    public static class ConfirmationViewModelExtensions
    {
        public static void Update(this ConfirmationViewModel viewModel, IConfirmationDialogRegister dialog)
        {
            viewModel.Message = dialog.Message;
            viewModel.Title = dialog.Title;
            viewModel.OkButton = dialog.OkButton;
            viewModel.CancelButton = dialog.CancelButton;
            viewModel.YesButton = dialog.YesButton;
            viewModel.NoButton = dialog.NoButton;
            viewModel.Severity = dialog.Severity;
            viewModel.Result = dialog.DefaultResult;
        }
    }
}
