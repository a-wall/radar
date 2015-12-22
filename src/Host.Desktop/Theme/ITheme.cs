using System;

namespace Host.Desktop.Theme
{
    public interface ITheme
    {
        string Name { get; }
        Uri ResourcePack { get; }
        string ImageSource { get; }
    }
}
