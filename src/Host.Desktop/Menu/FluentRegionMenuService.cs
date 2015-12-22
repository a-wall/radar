using Prism.Regions;

namespace Host.Desktop.Menu
{
    public sealed class FluentRegionMenuService : IMenuService
    {
        private readonly IRegionManager _regionManager;

        public FluentRegionMenuService(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public IMenu Menu(string menu)
        {
            return new FluentMenu(m =>
            {
                _regionManager.RegisterViewWithRegion(RegionNames.MenuBar, () => m);
            }, menu);
        }

        public IMenu SystemMenu(string menu)
        {
            return new FluentMenu(m =>
            {
                _regionManager.RegisterViewWithRegion(RegionNames.SystemMenuBar, () => m);
            }, menu);
        }
    }
}
