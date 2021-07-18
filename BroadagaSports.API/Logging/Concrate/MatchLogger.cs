using BroadagaSports.API.Logging.Abstract;
using Serilog;

namespace BroadagaSports.API.Logging.Concrate
{
    public class MatchLogger : IMatchLogger
    {
        public void Debug(string message)
        {
            Log.Debug(message);
        }

        public void Error(string message)
        {
            Log.Error(message);
        }

        public void LogFatal(string message)
        {
            Log.Fatal(message);
        }

        public void LogInfo(string message)
        {
            Log.Information(message);
        }

        public void LogWarning(string message)
        {
            Log.Warning(message);
        }
    }
}
