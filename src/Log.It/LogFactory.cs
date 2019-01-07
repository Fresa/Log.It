using System;

namespace Log.It
{
    public static class LogFactory
    {
        private static ILogFactory _factory;

        public static bool HasFactory 
            => _factory != null;

        public static void Initialize(ILogFactory logFactory)
        {
            if (HasFactory)
            {
                throw new InvalidOperationException("The log factory has already been initialized");
            }

            _factory = logFactory;
        }

        /// <summary>
        /// Creates a logger based on a type.
        /// </summary>
        /// <typeparam name="T">Type that will be used to determine the logger name</typeparam>
        /// <returns>Logger</returns>
        public static ILogger Create<T>()
        {
            if (HasFactory == false)
            {
                throw new InvalidOperationException($"Initialize the log factory before using it by calling {nameof(LogFactory)}.{nameof(Initialize)}({nameof(ILogFactory)} logFactory)");
            }

            return _factory.Create<T>();
        }

        /// <summary>
        /// Creates a logger based on a string.
        /// </summary>
        /// <param name="logger">Logger name</param>
        /// <returns>Logger</returns>
        public static ILogger Create(string logger)
        {
            if (HasFactory == false)
            {
                throw new InvalidOperationException($"Initialize the log factory before using it by calling {nameof(LogFactory)}.{nameof(Initialize)}({nameof(ILogFactory)} logFactory)");
            }

            return _factory.Create(logger);
        }
    }
}