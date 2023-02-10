using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATST.Diagnotics
{
    public static class Log
    {
        public delegate void LogEventHandler(string msg);
        public static event LogEventHandler OutputLog;

        private static TextWriter mWriter = null;
        private static readonly object mLock = new object();

        public static void WriteLine(string msg)
        {
            if (OutputLog == null)
                return;

            string log = String.Format("{0} {1}{2}",
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"),
                msg, Environment.NewLine);
            OutputLog(log);

            WriteFileLog(log);
        }

        private static void WriteFileLog(string message)
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            if (string.IsNullOrEmpty(baseDirectory))
                return;

            string folderPath = baseDirectory + "Log"; 
            DirectoryInfo di = new DirectoryInfo(folderPath);

            if (!di.Exists)
                di.Create();

            baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            baseDirectory = baseDirectory + "Log" +"\\log_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";

            if (!File.Exists(baseDirectory))
            {
                FileStream fileStream = File.Create(baseDirectory);
                fileStream.Close();
            }

            if (File.Exists(baseDirectory))
            {
                if (mWriter == null)
                    mWriter = new StreamWriter(baseDirectory, append: true, Encoding.Default);
            }

            // 데이터 쓰기 스트림이 동시에 생성되었을때 동시처리 문제를 해결하기 위함.
            lock (mLock)
            {
                mWriter.WriteLine(message);
                mWriter.Flush();
            }
        }
        

        public static void WriteLine()
        { WriteLine(String.Empty); }
        public static void WriteLine(string format, params object[] args)
        { WriteLine(String.Format(format, args)); }
        public static void WriteLine(string format, object arg0)
        { WriteLine(String.Format(format, arg0)); }
        public static void WriteLine(string format, object arg0, object arg1)
        { WriteLine(String.Format(format, arg0, arg1)); }
        public static void WriteLine(string format, object arg0, object arg1, object arg2)
        { WriteLine(String.Format(format, arg0, arg1, arg2)); }
    }
}
