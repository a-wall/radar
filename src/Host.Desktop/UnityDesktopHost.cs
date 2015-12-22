using System;
using System.Diagnostics;
using System.Reactive.Subjects;
using Microsoft.Practices.Unity;
using System.Windows;
using Host.Desktop.Bootstrappers;
using Host.Desktop.Core;

namespace Host.Desktop
{
    public sealed class UnityDesktopHost : IHost
    {
        private readonly IUnityContainer _container;
        private readonly IObserver<Exception> _exceptionObserver;

        public UnityDesktopHost(ResourceDictionary resources)
        {
            _container = new UnityContainer();
            _container.RegisterInstance(_container, new ExternallyControlledLifetimeManager());
            _container.RegisterInstance(resources, new ExternallyControlledLifetimeManager());
            var exceptions = new Subject<Exception>();
            _exceptionObserver = exceptions;
            _container.RegisterInstance(typeof (IObservable<Exception>), exceptions);
        }

        public IUnityContainer Container
        {
            get
            {
                return _container;
            }
        }

        public void Run()
        {
            IBootstrapper bootstrapper = new UnityDesktopBootstrapper(_container);

            if (!Debugger.IsAttached)
            {
                Action<Exception> errorAction = ex => _exceptionObserver.OnNext(ex);
                bootstrapper = new CorruptedStateExceptionHandlingBootstrapper(bootstrapper, errorAction);
                bootstrapper = new UnhandledExceptionHandlingBootstrapper(bootstrapper, errorAction);
                bootstrapper = new UnobservedTaskExceptionHandlingBootstrapper(bootstrapper, errorAction);
                bootstrapper = new DispatcherUnhandledExceptionHandlingBootstrapper(bootstrapper, errorAction);
            }

            bootstrapper.Run();
        }
    }
}
