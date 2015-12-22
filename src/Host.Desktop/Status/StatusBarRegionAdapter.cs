using System.Collections.Specialized;
using System.Windows.Controls.Primitives;
using Prism.Regions;

namespace Host.Desktop.Status
{
    public sealed class StatusBarRegionAdapter : RegionAdapterBase<StatusBar>
    {
        public StatusBarRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory) : base(regionBehaviorFactory)
        {
        }

        protected override void Adapt(IRegion region, StatusBar regionTarget)
        {
            region.ActiveViews.CollectionChanged += (o, e) =>
            {
                switch (e.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        foreach (IStatusBarItemRegister newItem in e.NewItems)
                        {
                            var statusBarItem = newItem.ToStatusBarItem();
                            regionTarget.Items.Add(statusBarItem);
                        }
                        break;
                }
            };
        }

        protected override IRegion CreateRegion()
        {
            return new AllActiveRegion();
        }
    }
}
