using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Logger
{
    public class FileLogger : LoggerBase
    {
        private string _FilePath = AppDomain.CurrentDomain.BaseDirectory + @"/Log/";
        private string _FileName = "";
        public FileLogger(LogLevel logLevel) : base(logLevel)
        {
            //创建文件夹
            if(!Directory.Exists(_FilePath))
                Directory.CreateDirectory(_FilePath);

            //创建日志文件
            _FileName = _FilePath + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ".log";
            var fileStream = new FileStream(_FileName, FileMode.Create);
            fileStream.Close();
        }

        private object _Lock = new object();

        public override bool WriteLine(MessageType Type, string Message)
        {
            if((int)Type > (int)base._LogLevel)
                return false;

            lock (_Lock)
            {
                var writer = new StreamWriter(_FileName, true);
                writer.WriteLine(Message);
                writer.Flush();
                writer.Close();
            }
            return true;
        }
    }
}
