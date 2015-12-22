using System.Reactive.Concurrency;
using Host.Desktop.Status;
using Prism.Modularity;
using Radar.Ui.View;
using Radar.Ui.ViewController;

namespace Radar.Ui
{
    public sealed class ConnectivityModule : IModule
    {
        private readonly IStatusBarService _statusBarService;

        public ConnectivityModule(IStatusBarService statusBarService)
        {
            _statusBarService = statusBarService;
        }

        public void Initialize()
        {
            var controller = new ConnectivityViewController(TaskPoolScheduler.Default);
            _statusBarService.View(() => new ConnectivityView()).ViewModel(() => controller.ViewModel);
        }
    }
}
