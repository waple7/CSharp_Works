using Serilog;

namespace Backups.Extra.Logging
{
    public class FileLogger : ILogger
    {
        public FileLogger(string path)
        {
            Path = path;
        }

        public string Path { get; set; }

        public void Log(string message)
        {
            Serilog.Core.Logger logger = new LoggerConfiguration()
                .WriteTo.File(Path)
                .CreateLogger();
            logger.Information(message);
        }
    }
}
