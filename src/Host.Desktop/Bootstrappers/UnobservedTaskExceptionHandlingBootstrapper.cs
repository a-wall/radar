using System;
using System.Threading.Tasks;
using Host.Desktop.Core;

namespace Host.Desktop.Bootstrappers
{
    public sealed class UnobservedTaskExceptionHandlingBootstrapper : IBootstrapper
    {
        private readonly IBootstrapper _bootstrapper;
        private readonly Action<Exception> _action;

        public UnobservedTaskExceptionHandlingBootstrapper(IBootstrapper bootstrapper, Action<Exception> action)
        {
            _bootstrapper = bootstrapper;
            _action = action;
        }

        public void Run()
        {
            TaskScheduler.UnobservedTaskException += TaskSchedulerOnUnobservedTaskException;

            _bootstrapper.Run();
            
        }

        private void TaskSchedulerOnUnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            if (e.Observed)
                return;

            e.SetObserved();
            _action(e.Exception);
        }
    }
}
