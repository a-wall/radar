using System.Windows.Controls.Primitives;

namespace Host.Desktop.Status
{
    public static class StatusBarExtensions
    {
        public static StatusBarItem ToStatusBarItem(this IStatusBarItemRegister itemRegister)
        {
            var view = itemRegister.ViewFactory();
            view.DataContext = itemRegister.ViewModelFactory();

            return new StatusBarItem
            {
                Content=view
            };
        }
    }
}
