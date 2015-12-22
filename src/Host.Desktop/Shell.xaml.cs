using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Host.Desktop.Core;

namespace Host.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Shell : MetroWindow, IShell
    {
        public Shell()
        {
            InitializeComponent();
        }

        public void AddKeyBinding(ICommand command, KeyGesture keyGesture)
        {
            InputBindings.Add(new KeyBinding(command, keyGesture));
        }
    }
}
