using System.Collections.Specialized;
using System.Windows.Controls;
using Host.Desktop.Core;
using Prism.Regions;

namespace Host.Desktop.Menu
{
    public sealed class MenuRegionAdapter : RegionAdapterBase<System.Windows.Controls.Menu>
    {
        private readonly IShell _shell;

        public MenuRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory, IShell shell) : base(regionBehaviorFactory)
        {
            _shell = shell;
        }

        protected override void Adapt(IRegion region, System.Windows.Controls.Menu regionTarget)
        {
            region.ActiveViews.CollectionChanged += (o, e) =>
            {
                switch (e.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        foreach (IMenuRegister m in e.NewItems)
                        {
                            var menuRegister = m;
                            var items = regionTarget.Items;
                            MenuItem menuItem = null;
                            MenuItem topLevelItem = null;
                            bool existing = false;

                            while (menuRegister != null)
                            {
                                MenuItem existingItem;
                                if (menuRegister.TryFindExistingMenu(items, out existingItem))
                                {
                                    menuRegister = menuRegister.SubMenu;
                                    items = existingItem.Items;
                                    menuItem = existingItem;
                                    existing = true;
                                    continue;
                                }

                                var newMenuItem = menuRegister.ToMenuItem(_shell);
                                if (existing)
                                {
                                    var menuTag = newMenuItem.Tag as MenuTag;
                                    if (menuTag != null)
                                        if (!string.IsNullOrEmpty(menuTag.Group))
                                            menuItem.Items.Add(new Separator());
                                    menuItem.Items.Add(newMenuItem);
                                    
                                }
                                else
                                {
                                    topLevelItem = newMenuItem;
                                }
                                menuItem = newMenuItem;
                                while (menuRegister.SubMenu != null)
                                {
                                    menuRegister = menuRegister.SubMenu;
                                    var subMenu = menuRegister.ToMenuItem(_shell);
                                    menuItem.Items.Add(subMenu);
                                    menuItem = subMenu;
                                    
                                }
                                break;
                            }

                            if (topLevelItem != null)
                                regionTarget.Items.Add(topLevelItem);
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
