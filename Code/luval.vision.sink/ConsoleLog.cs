using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.app
{
    public class ConsoleLog : ICustomLog
    {
        ConsoleColor _consoleColor;
        public ConsoleLog()
        {
            _consoleColor = Console.ForegroundColor;
        }

        public void Write(string category, string format, params object[] args)
        {
            var msg = string.Format(format, args);
            Console.ForegroundColor = GetColor(category);
            Console.WriteLine(string.Format("[{0}]-[{1}]: {2}", category, DateTime.Now.ToString("hh:mm:ss"), msg));
            Console.ForegroundColor = _consoleColor;
        }

        public void WriteError(string format, params object[] args)
        {
            Write("Error", format, args);
        }

        public void WriteInformation(string format, params object[] args)
        {
            Write("Information", format, args);
        }

        public void WriteWarning(string format, params object[] args)
        {
            Write("Warning", format, args);
        }

        private ConsoleColor GetColor(string cat)
        {
            switch (cat)
            {
                case "Error": return ConsoleColor.Red;
                case "Warning": return ConsoleColor.DarkYellow;
                default: return _consoleColor;
            }
        }
    }
}
