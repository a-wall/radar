using Host.Desktop;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Radar.Ui;
using System.Windows;
using Host.Desktop.Logging;
using Host.Desktop.Preference;
using Host.Desktop.Support;
using Host.Desktop.Theme;
using Host.Desktop.Themes;

namespace Radar.Viewer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var catalog = new ModuleCatalog();
            catalog.AddModule(typeof(ShellServicesModule));
            catalog.AddModule(typeof(FlatDarkThemeModule));
            catalog.AddModule(typeof(FlatLightThemeModule));
            catalog.AddModule(typeof(PreferencesModule));
            catalog.AddModule(typeof(ThemeModule));
            catalog.AddModule(typeof(SupportModule));
            catalog.AddModule(typeof(UtilitiesModule));
            catalog.AddModule(typeof(ConnectivityModule));

            var host = new UnityDesktopHost(Resources);
            host.Container.RegisterInstance(typeof(IModuleCatalog), catalog, new ContainerControlledLifetimeManager());
            host.UseNLog();
            host.Run();
        }
    }
}
