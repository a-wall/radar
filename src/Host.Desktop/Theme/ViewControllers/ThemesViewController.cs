using System;
using System.Collections.Generic;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Host.Desktop.Theme.ViewModels;

namespace Host.Desktop.Theme.ViewControllers
{
    public class ThemesViewController : IDisposable
    {
        private readonly IObservable<IEnumerable<ITheme>> _themes;
        private readonly IObservable<ITheme> _activeTheme;
        private readonly IScheduler _scheduler;

        private readonly ThemesViewModel _viewModel = new ThemesViewModel();
        private readonly SingleAssignmentDisposable _subscription = new SingleAssignmentDisposable();

        public ThemesViewController(IObservable<IEnumerable<ITheme>> themes, IObservable<ITheme> activeTheme, IScheduler scheduler)
        {
            _themes = themes;
            _activeTheme = activeTheme;
            _scheduler = scheduler;

        }

        public ThemesViewModel ViewModel
        {
            get { return _viewModel; }
        }

        public void Initialize(string defaultTheme)
        {
            _viewModel.Theme = new ThemeViewModel {Name = defaultTheme};
            _activeTheme.Where(t => t != null)
                .ObserveOn(_scheduler)
                .Subscribe(t => _viewModel.Theme = t.ToViewModel());
            _subscription.Disposable = _themes.Where(ts => ts != null)
                .ObserveOn(_scheduler)
                .Subscribe(_viewModel.Update);
        }

        public void Dispose()
        {
            _subscription.Dispose();
        }
    }
}
