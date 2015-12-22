using System;
using System.Diagnostics;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Interactivity;
using Host.Desktop.Behaviors;
using Host.Desktop.Dialog.ViewModels;
using Host.Desktop.Dialog.Views;
using Host.Desktop.Window;
using MahApps.Metro.Controls;
using Prism.Commands;

namespace Host.Desktop.Dialog.Actions
{
    public sealed class ShowDialogAction : IDialogAction
    {
        private readonly System.Windows.Window _owner;
        private readonly Func<System.Windows.Window, bool, bool?> _showAction;

        public ShowDialogAction(System.Windows.Window owner, Func<System.Windows.Window, bool, bool?> showAction)
        {
            _owner = owner;
            _showAction = showAction;
        }

        public void ShowDialog(IDialogRegister dialog)
        {
            var windowEvents = new Subject<WindowEvent>();
            var view = dialog.ViewFactory();
            var viewModel = dialog.ViewModelFactory(windowEvents.AsObservable());
            view.DataContext = viewModel;

            var window = CreateWindow(view, dialog.Owner ?? _owner, dialog);

            Observable.FromEventPattern<KeyEventHandler, KeyEventArgs>(h => window.KeyDown += h,
                h => window.KeyDown -= h)
                .Where(evp => evp.EventArgs.Key == Key.Escape)
                .Take(1)
                .Subscribe(e =>
                {
                    window.Close();
                    e.EventArgs.Handled = true;
                });

            Observable.FromEventPattern(h => window.Closed += h,
                h => window.Closed -= h)
                .Take(1)
                .Subscribe(e =>
                {
                    windowEvents.OnNext(WindowEvent.Closed);
                });

            if (!(viewModel is IDialogAware))
            {
                window.Title = dialog.Name;
            }
            else
            {
                var dialogAware = viewModel as IDialogAware;
                dialogAware.CloseCommand = new DelegateCommand(window.Close);
                window.SetBinding(System.Windows.Window.TitleProperty, new Binding("Title") {Source = dialogAware});
            }

            _showAction(window, false);
        }

        public ConfirmationResult ShowDialog(IConfirmationDialogRegister dialog)
        {
            var view = new ConfirmationView();
            var viewModel = new ConfirmationViewModel();
            viewModel.Update(dialog);
            view.DataContext = viewModel;
            var window = CreateWindow(view, dialog.Owner ?? _owner);
            window.SetBinding(System.Windows.Window.TitleProperty, new Binding("Title") {Source = viewModel});
            viewModel.CloseCommand = new DelegateCommand<ConfirmationResult?>(x =>
            {
                viewModel.Result = x ?? dialog.DefaultResult;
                window.Close();
            });

            var result = _showAction(window, true);

            if (!result.HasValue)
                return ConfirmationResult.None;

            return viewModel.Result;
        }

        private System.Windows.Window CreateWindow(FrameworkElement view, System.Windows.Window owner,
            IDialogRegister dialog = null)
        {
            var window = new MetroWindow()
            {
                Content = view,
                ResizeMode =
                    dialog == null
                        ? ResizeMode.NoResize
                        : dialog.AllowResize ? ResizeMode.CanResize : ResizeMode.NoResize,
                Topmost = !Debugger.IsAttached,
                ShowInTaskbar = false,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };

            window.SetResourceReference(FrameworkElement.StyleProperty, "Window");

            if (owner != null && owner.IsVisible)
                window.Owner = owner;

            if (dialog != null && dialog.Size.HasValue)
            {
                window.Width = dialog.Size.Value.Width;
                window.Height = dialog.Size.Value.Height;
            }
            else if (double.IsNaN(view.Width) && double.IsNaN(view.Height))
            {
                window.SizeToContent = SizeToContent.WidthAndHeight;
                var behaviors = Interaction.GetBehaviors(window);
                if (behaviors != null)
                    behaviors.Add(new WindowChromeSizeToContentBehavior());
            }
            else if (double.IsNaN(view.Width))
            {
                window.SizeToContent = SizeToContent.Width;
                window.Height = view.Height + SystemParameters.WindowCaptionHeight +
                                 SystemParameters.ResizeFrameHorizontalBorderHeight;
            }
            else if (double.IsNaN(view.Height))
            {
                window.SizeToContent = SizeToContent.Height;
                window.Width = view.Width +
                                 SystemParameters.ResizeFrameHorizontalBorderHeight;
            }
            else
            {
                window.SizeToContent = SizeToContent.Manual;
                window.Width = view.Width +
                                 SystemParameters.ResizeFrameHorizontalBorderHeight;
                window.Height = view.Height + SystemParameters.WindowCaptionHeight +
                                 SystemParameters.ResizeFrameHorizontalBorderHeight;

            }
            return window;
        }
    }
}
