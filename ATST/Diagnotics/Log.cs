using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATST.Diagnotics
{
    public static class Log
    {
        public delegate void LogEventHandler(string msg);
        public static event LogEventHandler OutputLog;

        public static void WriteLine(string msg)
        {
            if (OutputLog == null)
                return;

            string log = String.Format("{0} {1}{2}",
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"),
                msg, Environment.NewLine);
            OutputLog(log);
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
