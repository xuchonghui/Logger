using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public abstract class LoggerBase
    {
        protected readonly LogLevel _LogLevel = LogLevel.DEBUG;

        public LoggerBase(LogLevel logLevel) => _LogLevel = logLevel;

        public static string MessageFormart(string Message,bool IsDetailMode,MessageType Type,string CallerName,string FileName,int Line)
        {
            var builder = new StringBuilder();
            builder.Append($"[{Type.ToString().PadRight(20)}]  ");
            builder.Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "  ");
            if (IsDetailMode)
            {
                builder.Append(Path.GetFileName(CallerName) + " > ");
                builder.Append(CallerName + "() > ");
                builder.Append(Line.ToString().PadLeft(4));
            }
            builder.Append(Message);
            return builder.ToString();

        }

        public abstract bool WriteLine(MessageType Level, string Message);
    }
}
