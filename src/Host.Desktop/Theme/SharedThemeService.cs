using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Windows;
using Host.Desktop.Resource;

namespace Host.Desktop.Theme
{
    public class SharedThemeService : IThemeService
    {
        private readonly ResourceDictionary _resourceDictionary;
        private readonly BehaviorSubject<IEnumerable<ITheme>> _themes;
        private readonly BehaviorSubject<ITheme> _activeTheme;
        private readonly IDictionary<string, ITheme> _themesMap;

        public SharedThemeService(ResourceDictionary resourceDictionary)
        {
            _resourceDictionary = resourceDictionary;
            _themes = new BehaviorSubject<IEnumerable<ITheme>>(Enumerable.Empty<ITheme>());
            _activeTheme = new BehaviorSubject<ITheme>(null);
            _themesMap = new Dictionary<string, ITheme>();
        }

        public void RegisterTheme(string name, string resourcePack, string imageSource)
        {
            var theme = new Theme(name, new Uri(resourcePack), imageSource);
            _themesMap.Add(name, theme);
            _themes.OnNext(_themesMap.Values.ToArray());
        }

        public void SetTheme(string name)
        {
            ITheme theme;
            if (!_themesMap.TryGetValue(name, out theme)) return;
            var newTheme = new SharedResourceDictionary { Source = theme.ResourcePack };
            _resourceDictionary.MergedDictionaries.Add(newTheme);
            _activeTheme.OnNext(theme);
        }

        public IObservable<ITheme> ObserveActiveTheme()
        {
            return _activeTheme.AsObservable();
        }

        public IObservable<IEnumerable<ITheme>> ObserveThemes()
        {
            return _themes.AsObservable();
        }
    }
}