using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
                logger.WriteLine(MessageType.INFO,"".PadLeft(20,'*') +$"Logger is creat in {DateTime.Now.ToString("F")}"+ "".PadLeft(20, '*'));
            });
        }

        public static void LoggerCancel()
        {
            loggers.ForEach(logger =>
            {
                logger.WriteLine(MessageType.INFO, "".PadLeft(20, '*') + $"Logger is destroy in {DateTime.Now.ToString("F")}" + "".PadLeft(20, '*'));
            });
            loggers.Clear();
        }

        public static void WriteDebug(string Message,[CallerMemberName] string CallerName = null,[CallerFilePath]string FilePath = null,[CallerLineNumber]int Line = 0)
        {
            WriteMessage(MessageType.DEBUG, Message, CallerName, FilePath, Line);
        }

        public static void WriteInfo(string Message, [CallerMemberName] string CallerName = null, [CallerFilePath] string FilePath = null, [CallerLineNumber] int Line = 0)
        {
            WriteMessage(MessageType.INFO, Message, CallerName, FilePath, Line);
        }

        public static void WriteWarn(string Message, [CallerMemberName] string CallerName = null, [CallerFilePath] string FilePath = null, [CallerLineNumber] int Line = 0)
        {
            WriteMessage(MessageType.WARN, Message, CallerName, FilePath, Line);
        }

        public static void WriteError(string Message, [CallerMemberName] string CallerName = null, [CallerFilePath] string FilePath = null, [CallerLineNumber] int Line = 0)
        {
            WriteMessage(MessageType.ERROR, Message, CallerName, FilePath, Line);
        }

        public static void WriteFatal(string Message, [CallerMemberName] string CallerName = null, [CallerFilePath] string FilePath = null, [CallerLineNumber] int Line = 0)
        {
            WriteMessage(MessageType.FATAL, Message, CallerName, FilePath, Line);
        }

        public static void WriteMessage(MessageType Type,string Message,string CallerName,string FileName,int Line)
        {
            var msg = LoggerBase.MessageFormart(Message, true ,Type, CallerName, FileName, Line);
            loggers.ForEach((logger) =>
            {
                logger.WriteLine(Type, msg);
            });
        }
    }
}
