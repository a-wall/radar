using System;

namespace Host.Desktop.Dialog
{
    public sealed class FluentConfirmationDialog : IConfirmationDialog, IConfirmationDialogRegister
    {
        private string _title;
        private readonly Func<IConfirmationDialogRegister, ConfirmationResult> _dialogFunction;
        private string _message;
        private System.Windows.Window _owner;
        private bool _okButton;
        private bool _cancelButton;
        private bool _yesButton;
        private bool _noButton;
        private ConfirmationSeverity _severity;
        private ConfirmationResult _defaultResult;

        public FluentConfirmationDialog(string title, Func<IConfirmationDialogRegister, ConfirmationResult> dialogFunction)
        {
            _title = title;
            _dialogFunction = dialogFunction;
        }


        public IConfirmationDialog Message(string message)
        {
            _message = message;
            return this;
        }

        public IConfirmationDialog Owner(System.Windows.Window owner)
        {
            _owner = owner;
            return this;
        }

        public IConfirmationDialog Severity(ConfirmationSeverity severity)
        {
            _severity = severity;
            return this;
        }

        public IConfirmationDialog OkButton()
        {
            _okButton = true;
            return this;
        }

        public IConfirmationDialog CancelButton()
        {
            _cancelButton = true;
            return this;
        }

        public IConfirmationDialog YesButton()
        {
            _yesButton = true;
            return this;
        }

        public IConfirmationDialog NoButton()
        {
            _noButton = true;
            return this;
        }

        public IConfirmationDialog DefaultResult(ConfirmationResult defaultResult)
        {
            _defaultResult = defaultResult;
            return this;
        }

        public ConfirmationResult Show()
        {
            return _dialogFunction(this);
        }

        string IConfirmationDialogRegister.Title
        {
            get { return _title; }
        }

        string IConfirmationDialogRegister.Message
        {
            get { return _message; }
        }

        System.Windows.Window IConfirmationDialogRegister.Owner
        {
            get { return _owner; }
        }

        bool IConfirmationDialogRegister.OkButton
        {
            get { return _okButton; }
        }

        bool IConfirmationDialogRegister.CancelButton
        {
            get { return _cancelButton; }
        }

        bool IConfirmationDialogRegister.YesButton
        {
            get { return _yesButton; }
        }

        bool IConfirmationDialogRegister.NoButton
        {
            get { return _noButton; }
        }

        ConfirmationSeverity IConfirmationDialogRegister.Severity
        {
            get { return _severity; }
        }

        ConfirmationResult IConfirmationDialogRegister.DefaultResult
        {
            get { return _defaultResult; }
        }
    }
}