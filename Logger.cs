using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public static class Logger
    {
        private static List<LoggerBase> loggers = new List<LoggerBase>();

        public static void LoggerRegisterAll(LogLevel logLevel = LogLevel.DEBUG)
        {
            LoggerRegister(LoggerType.FileLogger | LoggerType.ConsoleLogger, logLevel);
        }

        public static void LoggerRegister(LoggerType loggerType, LogLevel logLevel)
        {
            if(loggerType.HasFlag(LoggerType.ConsoleLogger))
                loggers.Add(new ConsoleLogger(logLevel));

            if(loggerType.HasFlag(LoggerType.FileLogger))
                loggers.Add(new FileLogger(logLevel));

            loggers.ForEach(logger => 
            {
                logger.WriteLine(LogLevel.INFO,"".PadLeft(20,'*') +$"Logger is creat in {DateTime.Now.ToString("F")}"+ "".PadLeft(20, '*'));
            });
        }

        public static void LoggerCancel()
        {
            loggers.ForEach(logger =>
            {
                logger.WriteLine(LogLevel.INFO, "".PadLeft(20, '*') + $"Logger is destroy in {DateTime.Now.ToString("F")}" + "".PadLeft(20, '*'));
            });
            loggers.Clear();
        }

    }
}
