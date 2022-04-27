using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public class ConsoleLogger : LoggerBase
    {
        public ConsoleLogger(LogLevel logLevel) : base(logLevel)
        {
        }

        public override bool WriteLine(LogLevel Level, string Message)
        {
            if (Level > base._LogLevel)return false;
            var oldColor = Console.ForegroundColor;
            switch(Level)
            {
                case LogLevel.DEBUG: Console.ForegroundColor = ConsoleColor.White; break;
                case LogLevel.INFO: Console.ForegroundColor = ConsoleColor.Blue; break;
                case LogLevel.WARN: Console.ForegroundColor = ConsoleColor.Yellow; break;
                case LogLevel.ERROR: Console.ForegroundColor = ConsoleColor.DarkYellow; break;
                case LogLevel.FATAL: Console.ForegroundColor = ConsoleColor.Red; break;
            }
            Console.WriteLine(Message);
            Console.ForegroundColor = oldColor;
            return true;
        }
    }
}
