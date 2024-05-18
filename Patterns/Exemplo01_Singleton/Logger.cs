using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exemplo01_Singleton
{
    public class Logger
    {
        private static Logger _instance;
        private Logger() { }

        public static Logger GetInstance()
        {
            if (_instance == null)
                _instance = new Logger();
            return _instance;
        }
        public void Log(string message)
        {
            Console.WriteLine($"[LOG]: {message}");
        }
    }
}
