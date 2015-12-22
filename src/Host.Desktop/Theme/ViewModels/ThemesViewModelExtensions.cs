using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Host.Desktop.Theme.ViewModels
{
    public static class ThemesViewModelExtensions
    {
        public static void Update(this ThemesViewModel viewModel, IEnumerable<ITheme> themes)
        {
            var viewModels = themes.Select(t => t.ToViewModel());
            if (viewModel.Theme == null)
                viewModel.Theme = viewModels.First();
            viewModel.Themes = new ObservableCollection<ThemeViewModel>(viewModels);
        }
    }
}
