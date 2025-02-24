using Microsoft.Extensions.Logging;

namespace BlockChainStorageApp.External.Logging
{
    public class FileLogger : ILogger
    {
        private static readonly object _lock = new object();
        private readonly string _logFilePath;

        public FileLogger(string logFilePath = "logs/app-log.txt")
        {
            _logFilePath = logFilePath;

            var logDirectory = Path.GetDirectoryName(_logFilePath);
            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }

            if (!File.Exists(_logFilePath))
            {
                File.Create(_logFilePath).Dispose();
            }
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            if (formatter == null) return;

            string message = formatter(state, exception);
            string logEntry = $"{DateTime.UtcNow:yyyy-MM-dd HH:mm:ss} [{logLevel}] {message}";

            if (exception != null)
            {
                logEntry += Environment.NewLine + $"Exception: {exception}";
            }

            lock (_lock) // Ensuring thread safety
            {
                try
                {
                    File.AppendAllText(_logFilePath, logEntry + Environment.NewLine);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to log message: {ex.Message}");
                }
            }
        }

        public bool IsEnabled(LogLevel logLevel) => true;

        public IDisposable BeginScope<TState>(TState state) => NullScope.Instance;
        public void LogError(string message) => Log(LogLevel.Error, new EventId(0), message, null, (s, e) => s.ToString());
        public void LogWarning(string message) => Log(LogLevel.Warning, new EventId(0), message, null, (s, e) => s.ToString());
    }

    internal class NullScope : IDisposable
    {
        public static NullScope Instance { get; } = new NullScope();
        public void Dispose() { }
    }
}
