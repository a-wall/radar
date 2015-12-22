using System;
using System.Windows;
using Prism.Regions;

namespace Host.Desktop.Status
{
    public interface IStatusBarService
    {
        IStatusBarItem View(Func<FrameworkElement> viewFactory);
    }

    class FluentRegionStatusBarService : IStatusBarService
    {
        private readonly IRegionManager _regionManager;

        public FluentRegionStatusBarService(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public IStatusBarItem View(Func<FrameworkElement> viewFactory)
        {
            return new FluentStatusBarItem(viewFactory, s =>
            {
                _regionManager.RegisterViewWithRegion(RegionNames.StatusBar, () => s);
            });
        }
    }
}
