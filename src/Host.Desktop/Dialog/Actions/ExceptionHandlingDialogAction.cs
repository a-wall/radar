using System;

namespace Host.Desktop.Dialog.Actions
{
    public sealed class ExceptionHandlingDialogAction : IDialogAction
    {
        private readonly IDialogAction _dialogAction;
        private readonly Action<Exception> _errorAction;

        public ExceptionHandlingDialogAction(IDialogAction dialogAction, Action<Exception> errorAction)
        {
            _dialogAction = dialogAction;
            _errorAction = errorAction;
        }

        public void ShowDialog(IDialogRegister dialog)
        {
            try
            {
                _dialogAction.ShowDialog(dialog);
            }
            catch (Exception ex)
            {
                _errorAction(new Exception($"Unexpected error thrown by {dialog.Name} dialog.", ex));
            }
        }

        public ConfirmationResult ShowDialog(IConfirmationDialogRegister dialog)
        {
            try
            {
                return _dialogAction.ShowDialog(dialog);
            }
            catch (Exception ex)
            {
                _errorAction(new Exception($"Unexpected error thrown by {dialog.Title} confirmation dialog.", ex));
            }
            return ConfirmationResult.None;
        }
    }
}
