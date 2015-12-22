using Radar.Ui.ViewModel;

namespace Radar.Ui.ViewController
{
    public sealed class AnalyticsViewController
    {
        public AnalyticsViewModel ViewModel { get; private set; }

        public AnalyticsViewController()
        {
            ViewModel = new AnalyticsViewModel();
            ViewModel.Label = "Super Label!";
        }
    }
}
