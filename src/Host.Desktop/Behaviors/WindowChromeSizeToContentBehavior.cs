using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interactivity;

namespace Host.Desktop.Behaviors
{
    public class WindowChromeSizeToContentBehavior : Behavior<System.Windows.Window>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            Window.ContentRendered += WindowOnContentRendered;
            Window.Unloaded += WindowOnUnloaded;
        }

        private void WindowOnUnloaded(object sender, RoutedEventArgs routedEventArgs)
        {
            Window.ContentRendered -= WindowOnContentRendered;
            Window.Unloaded -= WindowOnUnloaded;
        }

        private void WindowOnContentRendered(object sender, EventArgs eventArgs)
        {
            if (Window.SizeToContent == SizeToContent.WidthAndHeight)
            {
                Window.SizeToContent = SizeToContent.Manual;
                Window.SizeToContent = SizeToContent.WidthAndHeight;
            }
        }

        private System.Windows.Window Window => AssociatedObject;
    }
}
