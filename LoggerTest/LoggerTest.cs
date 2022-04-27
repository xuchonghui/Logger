using Logger;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LoggerTest
{
    [TestClass]
    public class LoggerTest
    {
        [TestMethod]
        public void ConsoleLoggerTest()
        {
            Logger.Logger.LoggerRegister(LoggerType.ConsoleLogger,LogLevel.FATAL);
            Logger.Logger.WriteDebug("hello");
        }
    }
}
