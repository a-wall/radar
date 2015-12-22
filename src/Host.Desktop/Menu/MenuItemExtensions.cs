using System.Collections;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Host.Desktop.Core;

namespace Host.Desktop.Menu
{
    public static class MenuItemExtensions
    {
        public static MenuItem ToMenuItem(this IMenuRegister menuRegister, IShell shell)
        {
            var menuItem = new MenuItem
            {
                Header = menuRegister.Name,
                FontWeight = menuRegister.FontWeight,
                Tag = new MenuTag(menuRegister.Name, menuRegister.Group),
                Command = menuRegister.Command,
                CommandParameter = menuRegister.CommandParameter,
                IsCheckable = menuRegister.Checkable,
                Icon = menuRegister.Icon,
                FlowDirection = menuRegister.FlowDirection
            };
            if (menuRegister.Gesture != null)
            {
                menuItem.InputGestureText = menuRegister.Gesture.GetDisplayStringForCulture(CultureInfo.CurrentCulture);
                shell.AddKeyBinding(menuItem.Command, menuRegister.Gesture);
            }
            INotifyPropertyChanged viewModel = null;
            if (menuRegister.ViewModelFactory != null)
            {
                viewModel = menuRegister.ViewModelFactory();
            }
            if (menuRegister.ViewFactory != null)
            {
                var view = menuRegister.ViewFactory(viewModel);
                view.DataContext = viewModel;
                menuItem.Header = view;
            }
            if (menuRegister.Style != null)
                menuItem.SetResourceReference(FrameworkElement.StyleProperty, menuRegister.Style);
            return menuItem;
        }

        public static bool TryFindExistingMenu(this IMenuRegister menuRegister, IEnumerable items, out MenuItem menuItem)
        {
            foreach (var menu in items.OfType<MenuItem>())
            {
                var tag = menu.Tag as MenuTag;
                if (tag != null && tag.Name == menuRegister.Name)
                {
                    menuItem = menu;
                    return true;
                }
            }

            menuItem = null;
            return false;
        }
    }
}
