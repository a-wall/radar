using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Host.Desktop.Core;
using Host.Desktop.Logging;
using Host.Desktop.Menu;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Radar.Ui.Commands;

namespace Radar.Ui
{
    public sealed class UtilitiesModule : IModule
    {
        private readonly IUnityContainer _container;
        private readonly IMenuService _menuService;

        public UtilitiesModule(
            IUnityContainer container,
            IMenuService menuService)
        {
            _container = container;
            _menuService = menuService;
        }

        public void Initialize()
        {
            _menuService.SystemMenu("_Utilities")
                .Menu("Generate Thumbnail")
                .Command(new GenerateThumbnailCommand(_container.Resolve<IShell>(), _container.Resolve<ILogger<GenerateThumbnailCommand>>()));
        }
    }
}
