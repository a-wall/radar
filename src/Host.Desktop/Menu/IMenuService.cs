namespace Host.Desktop.Menu
{
    public interface IMenuService
    {
        IMenu Menu(string menu);
        IMenu SystemMenu(string menu);
    }
}
