namespace Host.Desktop.Menu
{
    public class MenuTag
    {
        public string Name { get; private set; }
        public string Group { get; private set; }

        public MenuTag(string name, string @group)
        {
            Name = name;
            Group = @group;
        }
    }
}
