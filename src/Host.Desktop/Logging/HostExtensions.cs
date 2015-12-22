using Host.Desktop.Core;
using Microsoft.Practices.Unity;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace Host.Desktop.Logging
{
    public static class HostExtensions
    {
        public static void UseNLog(this IHost host)
        {
            var config = new LoggingConfiguration();

            var consoleTarget = new ColoredConsoleTarget();
            config.AddTarget("console", consoleTarget);

            var fileTarget = new FileTarget();
            config.AddTarget("file", fileTarget);

            var layout = @"${longdate}|${level:uppercase=true}|${threadid}|${logger}|${message}";

            consoleTarget.Layout = layout;
            fileTarget.FileName = @"${tempdir}\${processname}\Log\${processname}.${processinfo:Id}.log";
            fileTarget.ArchiveFileName = @"${tempdir}\${processname}\Log\${processname}.${processinfo:Id}.{###}.log";
            fileTarget.ArchiveEvery = FileArchivePeriod.Day;
            fileTarget.ArchiveAboveSize = 1024000;
            fileTarget.ArchiveNumbering = ArchiveNumberingMode.Rolling;
            fileTarget.MaxArchiveFiles = 10;
            fileTarget.ConcurrentWrites = false;
            fileTarget.KeepFileOpen = false;
            fileTarget.Layout = layout;

            config.LoggingRules.Add(new LoggingRule("*", NLog.LogLevel.Debug, consoleTarget));
            config.LoggingRules.Add(new LoggingRule("*", NLog.LogLevel.Info, fileTarget));

            LogManager.Configuration = config;

            host.Container.RegisterType(typeof (ILogger<>), typeof (NLogger<>));
        }
    }
}
