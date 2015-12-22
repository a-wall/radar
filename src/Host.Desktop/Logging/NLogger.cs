using NLog;

namespace Host.Desktop.Logging
{
    public sealed class NLogger<T> : ILogger<T>
    {
        private readonly Logger _logger = LogManager.GetLogger(typeof(T).Name);

        public bool IsDebugEnabled => _logger.IsDebugEnabled;
        public bool IsInfoEnabled => _logger.IsInfoEnabled;
        public bool IsWarnEnabled => _logger.IsWarnEnabled;
        public bool IsErrorEnabled => _logger.IsErrorEnabled;
        public bool IsFatalEnabled => _logger.IsFatalEnabled;

        public void Debug(string message, params object[] arguments)
        {
            _logger.Debug(message, arguments);
        }

        public void Info(string message, params object[] arguments)
        {
            _logger.Info(message, arguments);
        }

        public void Warn(string message, params object[] arguments)
        {
            _logger.Warn(message, arguments);
        }

        public void Error(string message, params object[] arguments)
        {
            _logger.Error(message, arguments);
        }

        public void Fatal(string message, params object[] arguments)
        {
            _logger.Fatal(message, arguments);
        }
    }
}
