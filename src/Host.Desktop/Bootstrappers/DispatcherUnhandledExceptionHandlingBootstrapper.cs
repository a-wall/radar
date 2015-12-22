using System;
using System.Windows.Threading;
using Host.Desktop.Core;

namespace Host.Desktop.Bootstrappers
{
    public sealed class DispatcherUnhandledExceptionHandlingBootstrapper : IBootstrapper
    {
        private readonly IBootstrapper _bootstrapper;
        private readonly Action<Exception> _action;

        public DispatcherUnhandledExceptionHandlingBootstrapper(IBootstrapper bootstrapper, Action<Exception> action)
        {
            _bootstrapper = bootstrapper;
            _action = action;
        }

        public void Run()
        {
            Dispatcher.CurrentDispatcher.UnhandledException += CurrentDispatcherOnUnhandledException;

            _bootstrapper.Run();
        }

        private void CurrentDispatcherOnUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            e.Handled = true;
            _action(e.Exception);
        }
    }
}
