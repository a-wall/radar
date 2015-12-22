using Microsoft.Practices.Unity;
using Prism.Unity;
using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Host.Desktop.Unity
{
    public class UnityDesktopBootstrapper : UnityBootstrapper, IBootstrapper
    {
        private readonly IUnityContainer _container;

        public UnityDesktopBootstrapper(IUnityContainer container)
        {
            _container = container;
        }

        protected override DependencyObject CreateShell()
        {
            return Container.TryResolve<IShell>() as DependencyObject;
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();

            Application.Current.MainWindow = (Window)Shell;
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureModuleCatalog()
        {
            var moduleCatalog = new ModuleCatalog();

            ModuleCatalog = moduleCatalog;
        }
    }
}
