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

        public override bool WriteLine(MessageType type, string Message)
        {
            if ((int)type > (int)base._LogLevel)return false;
            var oldColor = Console.ForegroundColor;
            switch(type)
            {
                case MessageType.DEBUG: Console.ForegroundColor = ConsoleColor.White; break;
                case MessageType.INFO: Console.ForegroundColor = ConsoleColor.Blue; break;
                case MessageType.WARN: Console.ForegroundColor = ConsoleColor.Yellow; break;
                case MessageType.ERROR: Console.ForegroundColor = ConsoleColor.DarkYellow; break;
                case MessageType.FATAL: Console.ForegroundColor = ConsoleColor.Red; break;
            }
            Console.WriteLine(Message);
            Console.ForegroundColor = oldColor;
            return true;
        }
    }
}
