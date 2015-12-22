using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Reactive;
using System.Reactive.Subjects;
using System.Windows;
using Host.Desktop.Core;
using Host.Desktop.Dialog;
using Host.Desktop.Dialog.Actions;
using Host.Desktop.Logging;
using Host.Desktop.Menu;
using Host.Desktop.Status;
using Host.Desktop.Theme;

namespace Host.Desktop
{
    public sealed class ShellServicesModule : IModule
    {
        private readonly IUnityContainer _container;
        private readonly IRegionManager _regionManager;
        private readonly IShell _shell;
        private readonly ResourceDictionary _resourceDictionary;

        public ShellServicesModule(
            IUnityContainer container, 
            IRegionManager regionManager, 
            IShell shell,
            ResourceDictionary resourceDictionary)
        {
            _container = container;
            _regionManager = regionManager;
            _shell = shell;
            _resourceDictionary = resourceDictionary;
        }

        public void Initialize()
        {
            _container.RegisterInstance<IThemeService>(new SharedThemeService(_resourceDictionary));
            _container.RegisterInstance<IMenuService>(new FluentRegionMenuService(_regionManager));
            _container.RegisterInstance<IStatusBarService>(new FluentRegionStatusBarService(_regionManager));

            var exceptionSubject = new Subject<Exception>();
            var exceptionLogger = _container.Resolve<ILogger<ShellServicesModule>>();
            exceptionSubject.Subscribe(ex => exceptionLogger.Error("{0}", ex));
            _container.RegisterInstance<IObserver<Exception>>(exceptionSubject.AsObserver());

            var dialogAction = new ShowDialogAction(_shell as System.Windows.Window, (w, m) =>
            {
                if (m) return w.ShowDialog();
                w.Show();
                return true;
            });
            _container.RegisterInstance<IDialogService>(
                new FluentDialogService(new ExceptionHandlingDialogAction(dialogAction,
                    ex => exceptionSubject.OnNext(ex))));
        }
    }
}
