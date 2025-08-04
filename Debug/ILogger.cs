using System;

namespace Automat.Debug
{
    public interface ILogger
    {
        void Log(string message);
        void SaveAllLogs();
    }
}