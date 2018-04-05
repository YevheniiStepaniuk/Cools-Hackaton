using System;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;

namespace Valeriy.Domain.Extensions
{
    public static class LoggingExtensions
    {
        public static void LogException(this Microsoft.Extensions.Logging.ILogger logger, Exception e)
        {
            foreach (var exception in e.GetInnerExceptions())
            {
                logger.LogError(exception.Message);
            }
        }

        public static ILoggingBuilder AddFileLogger(this ILoggingBuilder builder, string path = "Logs",
            LogEventLevel level = LogEventLevel.Debug)
        {
            var logger = new LoggerConfiguration()
                .WriteTo.RollingFile(path,outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level}] {Message}{NewLine}{Exception}")
                .CreateLogger();
            return builder.AddSerilog(logger);
        }

        public static ILoggingBuilder AddConsoleLogger(this ILoggingBuilder builder,
            LogEventLevel level = LogEventLevel.Debug)
        {
            var logger = new LoggerConfiguration()
                .WriteTo.ColoredConsole(level)
                .CreateLogger();
            return builder.AddSerilog(logger);
        }
    }
}