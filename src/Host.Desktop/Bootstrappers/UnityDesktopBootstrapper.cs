using System.Windows;
using System.Windows.Controls.Primitives;
using Host.Desktop.Core;
using Host.Desktop.Menu;
using Host.Desktop.Status;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;

namespace Host.Desktop.Bootstrappers
{
    public class UnityDesktopBootstrapper : UnityBootstrapper, IBootstrapper
    {
        private readonly IUnityContainer _container;

        public UnityDesktopBootstrapper(IUnityContainer container)
        {
            _container = container;
        }

        protected override IUnityContainer CreateContainer()
        {
            return _container;
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return _container.Resolve<IModuleCatalog>();
        }

        protected override DependencyObject CreateShell()
        {
            return _container.Resolve<IShell>() as DependencyObject;
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            RegisterTypeIfMissing(typeof(IShell), typeof(Shell), true);
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();

            Application.Current.MainWindow = (System.Windows.Window)Shell;
            Application.Current.MainWindow.Show();
        }

        protected override RegionAdapterMappings ConfigureRegionAdapterMappings()
        {
            var mappings = base.ConfigureRegionAdapterMappings();
            mappings.RegisterMapping(typeof(System.Windows.Controls.Menu), Container.Resolve<MenuRegionAdapter>());
            mappings.RegisterMapping(typeof(StatusBar), Container.Resolve<StatusBarRegionAdapter>());
            return mappings;
        }
    }
}
