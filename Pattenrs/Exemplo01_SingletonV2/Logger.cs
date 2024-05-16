using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exemplo01_Singleton
{
    public enum LogLevel
    {
        Info,
        Warning,
        Error
    }

    public class Logger
    {
        private static Logger _instance;
        private static readonly object lockObject = new object();
        private string logFile = "log.txt";
        private Logger()
        {
            File.WriteAllText(logFile, string.Empty);
        }
        public static Logger GetInstance()
        {
            if (_instance == null)
            {
                lock (lockObject)
                {
                    if (_instance == null)
                        _instance = new Logger();
                }
            }
            return _instance;
        }

        public void Log(LogLevel level, string message)
        {
            string logMessage = $"{DateTime.Now} [{level}] - {message}";
            using (StreamWriter writer = File.AppendText(logFile))
            {
                writer.WriteLine(logMessage);
            }
        }
    }

}
