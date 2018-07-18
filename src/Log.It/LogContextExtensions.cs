using System;

namespace Log.It
{
    public static partial class LogContextExtensions
    {
        public static IDisposable Capture<T>(this ILogContext logContext, string key, T value)
        {
            logContext.Set(key, value);
            return new DisposeAction(() => logContext.Remove(key));
        }
    }
}