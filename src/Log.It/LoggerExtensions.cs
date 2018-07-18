using System;

namespace Log.It
{
    public static partial class LoggerExtensions
    {
        public static IDisposable CaptureLogicalThreadContext<T>(this ILogger logger, string key, T value)
        {
            return logger.LogicalThread.Capture(key, value);
        }
    }
}