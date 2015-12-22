using System;

namespace Host.Desktop.Logging
{
    [Flags]
    public enum LogLevel
    {
        Unknown = 0,
        Debug = 1,
        Info = 2,
        Warn = 4,
        Error = 8,
        Fatal = 16
    }
}
