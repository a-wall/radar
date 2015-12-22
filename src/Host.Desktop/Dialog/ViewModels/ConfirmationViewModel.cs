using System.ComponentModel;
using System.Windows.Input;

namespace Host.Desktop.Dialog.ViewModels
{
    public class ConfirmationViewModel : INotifyPropertyChanged, IDialogAware
    {
        private ICommand _closeCommand;
        private string _title;
        public event PropertyChangedEventHandler PropertyChanged;
        private string _message;
        private bool _okButton;
        private bool _cancelButton;
        private bool _yesButton;
        private bool _noButton;
        private ConfirmationSeverity _severity;
        private ConfirmationResult _result;

        public ICommand CloseCommand
        {
            get { return _closeCommand; }
            set
            {
                if (Equals(_closeCommand, value)) return;
                _closeCommand = value;
                PropertyChanged.Raise(this, () => CloseCommand);
            }
        }

        public string Title
        {
            get { return _title; }
            set
            {
                if (Equals(_title, value)) return;
                _title = value;
                PropertyChanged.Raise(this, () => Title);
            }
        }

        public string Message
        {
            get { return _message; }
            set
            {
                if (Equals(_message, value)) return;
                _message = value;
                PropertyChanged.Raise(this, () => Message);
            }
        }

        public ConfirmationSeverity Severity
        {
            get { return _severity; }
            set
            {
                if (Equals(_severity, value)) return;
                _severity = value;
                PropertyChanged.Raise(this, () => Severity);
            }
        }

        public ConfirmationResult Result
        {
            get { return _result; }
            set
            {
                if (Equals(_result, value)) return;
                _result = value;
                PropertyChanged.Raise(this, () => Result);
            }
        }

        public bool OkButton
        {
            get { return _okButton; }
            set
            {
                if (Equals(_okButton, value)) return;
                _okButton = value;
                PropertyChanged.Raise(this, () => OkButton);
            }
        }

        public bool CancelButton
        {
            get { return _cancelButton; }
            set
            {
                if (Equals(_cancelButton, value)) return;
                _cancelButton = value;
                PropertyChanged.Raise(this, () => CancelButton);
            }
        }

        public bool YesButton
        {
            get { return _yesButton; }
            set
            {
                if (Equals(_yesButton, value)) return;
                _yesButton = value;
                PropertyChanged.Raise(this, () => YesButton);
            }
        }

        public bool NoButton
        {
            get { return _noButton; }
            set
            {
                if (Equals(_noButton, value)) return;
                _noButton = value;
                PropertyChanged.Raise(this, () => NoButton);
            }
        }
    }
}
