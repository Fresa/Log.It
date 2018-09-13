using System;
using System.Configuration;
using System.Diagnostics;
using System.Linq;

namespace Log.It
{
    public static class LogFactory
    {
        private static readonly ILogFactory Factory;

        private const string LoggingSection = "Logging";

        static LogFactory()
        {
            var loggingSection = ConfigurationManager.GetSection(LoggingSection) as LoggingSection;
            if (loggingSection == null)
            {
                throw new ConfigurationErrorsException(
                    $"Could not find {LoggingSection} configuration in configuration file.");
            }

            if (loggingSection.Factory.GetInterfaces().Any(type => type == typeof(ILoggerFactory)) == false)
            {
                throw new ConfigurationErrorsException(
                    $"{loggingSection.Factory.AssemblyQualifiedName} must implement {typeof(ILoggerFactory).FullName}.");
            }

            Factory = ((ILoggerFactory)Activator.CreateInstance(loggingSection.Factory)).Create();
        }

        /// <summary>
        /// Creates a logger based on a type.
        /// </summary>
        /// <typeparam name="T">Type that will be used to determine the logger name</typeparam>
        /// <returns>Logger</returns>
        public static ILogger Create<T>()
        {
            return Factory.Create<T>();
        }

        /// <summary>
        /// Creates a logger based on a string.
        /// </summary>
        /// <param name="logger">Logger name</param>
        /// <returns>Logger</returns>
        public static ILogger Create(string logger)
        {
            return Factory.Create(logger);
        }

        /// <summary>
        /// Creates a logger based on calling method's declaring type.
        /// <remarks>
        /// - Will not be able to resolve type arguments, resulting in empty &lt;&gt;
        /// - JIT optimization might cause the declaring type of the calling method to be null.
        /// In this case the logger name will be based on the calling method's name.
        /// </remarks>
        /// </summary>
        /// <returns>Logger</returns>
        public static ILogger Create()
        {
            var method = new StackFrame(1, false).GetMethod();

            var name = method.DeclaringType.GetPrettyName();
            if (string.IsNullOrEmpty(name))
            {
                name = method.Name;
            }

            return Create(name);
        }
    }
}