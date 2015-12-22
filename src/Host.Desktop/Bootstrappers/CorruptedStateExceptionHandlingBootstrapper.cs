using System;
using System.Runtime.ExceptionServices;
using System.Security;
using Host.Desktop.Core;

namespace Host.Desktop.Bootstrappers
{
    public sealed class CorruptedStateExceptionHandlingBootstrapper : IBootstrapper
    {
        private readonly IBootstrapper _bootstrapper;
        private readonly Action<Exception> _action;

        public CorruptedStateExceptionHandlingBootstrapper(IBootstrapper bootstrapper, Action<Exception> action)
        {
            _bootstrapper = bootstrapper;
            _action = action;
        }

        [HandleProcessCorruptedStateExceptions, SecurityCritical]
        public void Run()
        {
            try
            {
                _bootstrapper.Run();
            }
            catch (Exception e)
            {
                _action(e);
            }
        }
    }
}
