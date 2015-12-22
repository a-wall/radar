using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using Microsoft.Expression.Interactivity.Core;
using Prism.Commands;

namespace Host.Desktop.Menu
{
    public sealed class FluentMenu : IMenu, IMenuRegister
    {
        private Action<IMenuRegister> _completionAction;
        private IMenuRegister _subMenu;
        private readonly IMenuRegister _parentMenu;
        private string _name;
        private string _group;
        private FontWeight _fontWeight;
        private FrameworkElement _icon;
        private bool _checkable;
        private ICommand _command;
        private object _commandParameter;
        private string _style;
        private FlowDirection _flowDirection;
        private Func<INotifyPropertyChanged, FrameworkElement> _viewFactory;
        private Func<INotifyPropertyChanged> _viewModelFactory;
        private KeyGesture _gesture;

        public FluentMenu(Action<IMenuRegister> completionAction, string name)
            : this(completionAction, null, name)
        {
        }

        public FluentMenu(Action<IMenuRegister> completionAction, IMenuRegister parentMenu, string name)
        {
            _completionAction = completionAction;
            _parentMenu = parentMenu;
            _name = name;
            _flowDirection = FlowDirection.LeftToRight;
        }

        public IMenu Menu(string menu)
        {
            var subMenu = new FluentMenu(_completionAction, this, menu);
            _subMenu = subMenu;
            return subMenu;
        }

        IMenu IMenu.Group(string group)
        {
            _group = group;
            return this;
        }

        public IMenu Bold()
        {
            _fontWeight = FontWeights.Bold;
            return this;
        }

        IMenu IMenu.Style(string style)
        {
            _style = style;
            return this;
        }

        public IMenu View(Func<FrameworkElement> viewFactory)
        {
            _viewFactory = _ => viewFactory();
            return this;
        }

        public IMenu ViewModel(Func<INotifyPropertyChanged> viewModelFactory)
        {
            _viewModelFactory = viewModelFactory;
            return this;
        }

        public void Command(ICommand command)
        {
            Command(command, null);
        }

        public void Command(Action command)
        {
            Command(new DelegateCommand(command));
        }

        public void Command(ICommand command, object commandParameter)
        {
            _command = new ActionCommand(() =>
            {
                command.Execute(commandParameter);
            });
            _commandParameter = commandParameter;
            Complete(this);
        }

        private void Complete(IMenuRegister menuRegister)
        {
            var topLevelMenu = menuRegister;
            while (topLevelMenu.ParentMenu != null)
                topLevelMenu = topLevelMenu.ParentMenu;
            _completionAction(topLevelMenu);
        }

        public string Name
        {
            get { return _name; }
        }

        public string Group
        {
            get { return _group; }
        }

        public FontWeight FontWeight
        {
            get { return _fontWeight; }
        }

        public FrameworkElement Icon
        {
            get { return _icon; }
        }

        public bool Checkable
        {
            get { return _checkable; }
        }

        ICommand IMenuRegister.Command
        {
            get { return _command; }
        }

        public object CommandParameter
        {
            get { return _commandParameter; }
        }

        public string Style
        {
            get { return _style; }
        }

        public IMenuRegister SubMenu
        {
            get { return _subMenu; }
        }

        public IMenuRegister ParentMenu
        {
            get { return _parentMenu; }
        }

        public FlowDirection FlowDirection
        {
            get { return _flowDirection; }
        }

        public Func<INotifyPropertyChanged, FrameworkElement> ViewFactory
        {
            get { return _viewFactory; }
        }

        public Func<INotifyPropertyChanged> ViewModelFactory
        {
            get { return _viewModelFactory; }
        }

        public KeyGesture Gesture
        {
            get { return _gesture; }
        }
    }
}
