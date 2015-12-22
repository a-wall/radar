using System;
using Host.Desktop.Core;

namespace Host.Desktop.Bootstrappers
{
    public sealed class UnhandledExceptionHandlingBootstrapper : IBootstrapper
    {
        private readonly IBootstrapper _bootstrapper;
        private readonly Action<Exception> _action;

        public UnhandledExceptionHandlingBootstrapper(IBootstrapper bootstrapper, Action<Exception> action)
        {
            _bootstrapper = bootstrapper;
            _action = action;
        }

        public void Run()
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;
            _bootstrapper.Run();
        }

        private void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var exception = e.ExceptionObject as Exception;
            if (exception != null)
                _action(exception);
        }
    }
}
