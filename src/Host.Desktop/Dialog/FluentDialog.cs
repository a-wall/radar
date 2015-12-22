using System;
using System.ComponentModel;
using System.Windows;
using Host.Desktop.Window;

namespace Host.Desktop.Dialog
{
    public sealed class FluentDialog : IDialog, IDialogRegister
    {
        private readonly string _name;
        private readonly Action<IDialogRegister> _showAction;
        private System.Windows.Window _owner;
        private Func<FrameworkElement> _viewFactory;
        private Func<IObservable<WindowEvent>, INotifyPropertyChanged> _viewModelFactory;
        private bool _allowResize;
        private Size? _size;

        public FluentDialog(string name, Action<IDialogRegister> showAction)
        {
            _name = name;
            _showAction = showAction;
        }

        public string Name
        {
            get { return _name; }
        }

        public System.Windows.Window Owner
        {
            get { return _owner; }
        }

        public Func<FrameworkElement> ViewFactory
        {
            get { return _viewFactory; }
        }

        public Func<IObservable<WindowEvent>, INotifyPropertyChanged> ViewModelFactory
        {
            get { return _viewModelFactory; }
        }

        public bool AllowResize
        {
            get { return _allowResize; }
        }

        public Size? Size
        {
            get { return _size; }
        }

        IDialog IDialog.Owner(System.Windows.Window owner)
        {
            _owner = owner;
            return this;
        }

        public IDialog View(Func<FrameworkElement> viewFactory)
        {
            _viewFactory = viewFactory;
            return this;
        }

        public IDialog ViewModel(Func<IObservable<WindowEvent>, INotifyPropertyChanged> viewModelFactory)
        {
            _viewModelFactory = viewModelFactory;
            return this;
        }

        IDialog IDialog.Size(double width, double height)
        {
            _size = new Size(width, height);
            return this;
        }

        public void Show()
        {
            _showAction(this);
        }
    }
}