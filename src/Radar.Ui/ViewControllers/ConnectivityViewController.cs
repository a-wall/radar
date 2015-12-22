using System;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using Radar.Ui.ViewModel;

namespace Radar.Ui.ViewController
{
    public sealed class ConnectivityViewController : IDisposable
    {
        public ConnectivityViewModel ViewModel { get; private set; }
        private readonly IDisposable _subscription; 

        public ConnectivityViewController(IScheduler scheduler)
        {
            ViewModel = new ConnectivityViewModel();
            var random = new Random();
            _subscription = Observable.Timer(DateTimeOffset.UtcNow, TimeSpan.FromSeconds(2), scheduler)
                .Select(_ => random.Next(100) > 50).Subscribe(b =>
                {
                    ViewModel.Connected = b;
                });
        }

        public void Dispose()
        {
            _subscription.Dispose();
        }
    }
}
