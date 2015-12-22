namespace Host.Desktop.Logging
{
    public interface ILogger<out T>: ILogger { }

    public interface ILogger
    {
        bool IsDebugEnabled { get; }
        bool IsInfoEnabled { get; }
        bool IsWarnEnabled { get; }
        bool IsErrorEnabled { get; }
        bool IsFatalEnabled { get; }

        void Debug(string message, params object[] arguments);
        void Info(string message, params object[] arguments);
        void Warn(string message, params object[] arguments);
        void Error(string message, params object[] arguments);
        void Fatal(string message, params object[] arguments);
    }
}
