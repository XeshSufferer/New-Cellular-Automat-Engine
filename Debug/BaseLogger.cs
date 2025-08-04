using System;
using System.Collections.Generic;
using System.IO;

namespace Automat.Debug
{
    public class BaseLogger : ILogger
    {
        private List<string> _logs = new List<string>();

        public void Log(string message)
        {
            _logs.Add($"[{DateTime.Now}] {message}");
        }

        public void SaveAllLogs()
        {
            if(!File.Exists("logs.txt"))
            {
                File.Create("logs.txt");
            }

            File.WriteAllLines("logs.txt", _logs);
        }
    }
}