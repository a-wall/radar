using System;
using System.Collections.Generic;

namespace Host.Desktop.Theme
{
    public interface IThemeService
    {
        void RegisterTheme(string name, string resourcePack, string imageSource);

        void SetTheme(string name);

        IObservable<ITheme> ObserveActiveTheme();

        IObservable<IEnumerable<ITheme>> ObserveThemes();
    }
}
