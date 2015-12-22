using System.Windows.Media;
using Host.Desktop.Presentation;

namespace Host.Desktop.Theme.ViewModels
{
    public static class ThemeViewModelExtensions
    {
        public static ThemeViewModel ToViewModel(this ITheme theme)
        {
            ImageSource imageSource = null;
            if (theme.ImageSource != null)
                imageSource = theme.ImageSource.ToImageSource();

            return new ThemeViewModel()
            {
                Name = theme.Name,
                Image = imageSource
            };
        }
    }
}
