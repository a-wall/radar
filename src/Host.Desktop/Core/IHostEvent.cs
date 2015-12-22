namespace Host.Desktop.Core
{
    public interface IHostEvent
    {
        string Topic { get; }
        string User { get; }
        string Machine { get; }
        string ProcessName { get; }
        int Pid { get; }
    }
}
