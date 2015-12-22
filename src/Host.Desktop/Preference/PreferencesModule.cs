using Host.Desktop.Dialog;
using Host.Desktop.Menu;
using Host.Desktop.Preference.View;
using Host.Desktop.Preference.ViewController;
using Microsoft.Practices.Unity;
using Prism.Modularity;

namespace Host.Desktop.Preference
{
    public sealed class PreferencesModule : IModule
    {
        private readonly IUnityContainer _container;
        private readonly IMenuService _menuService;
        private readonly IDialogService _dialogService;

        public PreferencesModule(IUnityContainer container, IMenuService menuService, IDialogService dialogService)
        {
            _container = container;
            _menuService = menuService;
            _dialogService = dialogService;
        }

        public void Initialize()
        {
            var controller = new PreferencesViewController();
            var service = new FluentPreferencesService(controller.ViewModel.Add);
            _container.RegisterInstance<IPreferencesService>(service);
            _menuService.Menu("Application")
                .Bold()
                .Menu("Preferences...")
                .Group("Preferences")
                .Command(() =>
                {
                    _dialogService.Dialog("Preferences")
                    .View(() => new PreferencesView())
                    .ViewModel(_ => controller.ViewModel)
                    .Show();
                });
        }
    }
}
