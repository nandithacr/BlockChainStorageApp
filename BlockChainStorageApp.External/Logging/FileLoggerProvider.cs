using Microsoft.Extensions.Logging;

namespace BlockChainStorageApp.External.Logging
{
    public class FileLoggerProvider : ILoggerProvider
    {
        private readonly string _logFilePath;

        public FileLoggerProvider(string logFilePath = "logs/app-log.txt")
        {
            _logFilePath = logFilePath;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new FileLogger(_logFilePath);
        }

        public void Dispose() { }
    }
}
