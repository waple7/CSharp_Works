using Serilog;

namespace Backups.Extra.Logging
{
    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Serilog.Core.Logger logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
            logger.Information(message);
        }
    }
}
