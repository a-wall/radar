using Microsoft.Practices.Unity;

namespace Host.Desktop.Core
{
    public interface IHost
    {
        IUnityContainer Container { get; }

        void Run();
    }
}
