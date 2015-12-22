using System;

namespace Host.Desktop.Theme
{
    public class Theme : ITheme
    {
        public Theme(string name, Uri resourcePack, string imageSource)
        {
            Name = name;
            ResourcePack = resourcePack;
            ImageSource = imageSource;
        }

        public string Name { get; }

        public Uri ResourcePack { get; }

        public string ImageSource { get; }
    }
}