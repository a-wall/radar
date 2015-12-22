using System;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Windows;
using Host.Desktop.Preference;
using Host.Desktop.Setting;
using Host.Desktop.Theme.ViewControllers;
using Host.Desktop.Theme.Views;
using Prism.Modularity;

namespace Host.Desktop.Theme
{
    public sealed class ThemeModule : IModule
    {
        private readonly IPreferencesService _preferencesService;
        private readonly IThemeService _themeService;
        private readonly CompositeDisposable _disposable = new CompositeDisposable();

        public ThemeModule(
            IPreferencesService preferencesService, 
            IThemeService themeService)
        {
            _preferencesService = preferencesService;
            _themeService = themeService;
        }

        public async void Initialize()
        {
            var defaultTheme = (await _themeService.ObserveThemes().FirstAsync()).FirstOrDefault();
            if (defaultTheme != null) _themeService.SetTheme(defaultTheme.Name);
            
            var controller = new ThemesViewController(_themeService.ObserveThemes(), _themeService.ObserveActiveTheme(), DispatcherScheduler.Current);
            controller.Initialize(defaultTheme.Name);
            _disposable.Add(controller);

            _preferencesService.Preference("Themes")
                .Commit(() =>
                {
                    var theme = controller.ViewModel.Theme;
                    if (theme != null) _themeService.SetTheme(theme.Name);
                })
                .Revert(() => { })
                .Icon(new ThemesIconView())
                .View(() => new ThemesView())
                .ViewModel(() => controller.ViewModel);
        }
    }
}
