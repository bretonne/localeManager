using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LocaleManager.utils
{
    public static class LogUtils
    {
        //take a timetick when program starts and use it to save mismatched strings
        private static long _timeTick = DateTime.Now.Ticks;

        public static readonly string ErrLog = "LocaleManager.log";

        public static string MismatchLog
        {
            get { return "Mismatch_" + _timeTick + ".log";}
        }

        public static string DuplicateLog
        {
            get { return "Duplicate_" + _timeTick + ".log"; }
        }

        public static void Log(string path, string msg)
        {
            using (FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write))
            {
                using (StreamWriter wr = new StreamWriter(fs, Encoding.UTF8))
                {
                    wr.WriteLine(msg);
                    wr.Flush();
                    wr.Close();
                }
            }
        }
    }
}
