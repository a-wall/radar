using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Host.Desktop.Core;
using Host.Desktop.Logging;
using Host.Desktop.Presentation;

namespace Radar.Ui.Commands
{
    public sealed class GenerateThumbnailCommand : ICommand
    {
        private readonly IShell _shell;
        private readonly ILogger<GenerateThumbnailCommand> _logger;

        public GenerateThumbnailCommand(IShell shell, ILogger<GenerateThumbnailCommand> logger)
        {
            _shell = shell;
            _logger = logger;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var window = _shell as Window;
            var targetBitmap = new RenderTargetBitmap(175, 150, 96d, 96d, PixelFormats.Default);
            targetBitmap.Render(window);
            targetBitmap.Freeze();
            var thumbnail = targetBitmap.ToBase64String();
            _logger.Info(thumbnail);
          
        }

        event EventHandler ICommand.CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
