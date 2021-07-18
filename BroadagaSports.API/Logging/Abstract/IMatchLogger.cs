using System;

namespace BroadagaSports.API.Logging.Abstract
{
    public interface IMatchLogger
    {
        void LogInfo(String message);
        void LogWarning(String message);
        void Debug(String message);
        void Error(String message);
        void LogFatal(String message);
    }
}
