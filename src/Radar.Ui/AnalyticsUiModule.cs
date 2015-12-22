using Host.Desktop;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using Radar.Ui.View;
using Radar.Ui.ViewController;
using System.Reactive.Disposables;

namespace Radar.Ui
{
    public class AnalyticsUiModule : IModule
    {
        private readonly IRegionManager _regionManager;
        private readonly IUnityContainer _container;
        private readonly CompositeDisposable _disposable;

        public AnalyticsUiModule(IRegionManager regionManager, IUnityContainer container)
        {
            _regionManager = regionManager;
            _container = container;
            _disposable = new CompositeDisposable();
        }

        public void Initialize()
        {
            var controller = new AnalyticsViewController();

            _regionManager.RegisterViewWithRegion(RegionNames.Main, () => new AnalyticsView { DataContext = controller.ViewModel });

            //Observable.FromEventPattern<ExitEventHandler, ExitEventArgs>(h => Application.Current.Exit += h, h => Application.Current.Exit -= h)
            //          .Take(1)
            //          .Subscribe(_ => _disposable.Dispose());
        }
    }
}
