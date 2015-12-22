using Host.Desktop.Logging;
using Host.Desktop.Menu;
using Host.Desktop.Support.View;
using Prism.Modularity;

namespace Host.Desktop.Support
{
    public sealed class SupportModule : IModule
    {
        private readonly IMenuService _menuService;
        private readonly ILogger<SupportModule> _logger;

        public SupportModule(IMenuService menuService, ILogger<SupportModule> logger)
        {
            _menuService = menuService;
            _logger = logger;
        }

        public void Initialize()
        {
            _logger.Info("Setting up SupportModule");
            _menuService.SystemMenu("Support")
                .View(() => new SystemMenuIconView())
                .Menu("Shutdown")
                .Command(new ShutdownApplicationCommand());
            _menuService.SystemMenu("Support")
                .Menu("Restart ...")
                .Command(new RestartApplicationCommand());
        }
    }
}
