/******************************************************************
* 项目名称 ：Mir.Commons.Log 
* 项目描述 ： 
* 类 名 称 ：LogHelper 
* 类 描 述 ： 
* CLR 版本 ：4.0.30319.42000 
* 版权所有 ：袁振峰
* 联系方式 ：http://www.ustuy.com/ 
******************************************************************/
using System;
using System.IO;

namespace Mir.Commons.Log
{
    /// <summary>
    /// 日志输出类,默认输出位置为项目坐在文件夹的Log目录中,若要修改输出位置,请使用LogPath属性
    /// </summary>
    public static class LogFileHelper
    {
        private static string _logPath = AppContext.BaseDirectory + "\\Log\\";

        /// <summary>
        /// 获取日志目录
        /// </summary>
        public static string LogPath
        {
            get { return _logPath; }
            set { _logPath = value.Trim(); }
        }

        #region 普通日志

        /// <summary>
        /// 写普通日志，存放到默认路径，使用默认日志类型
        /// </summary>
        /// <param name="msg">日志内容</param>
        /// <param name="isConsole">是否打印内容</param>
        public static void WriteLog(string msg, bool isConsole = false)
        {
            if (isConsole)
            {
                PrintHelper.PrintLineWithTime(msg);
            }

            WriteLog(msg, LogType.Info);
        }

        /// <summary>
        /// 写普通日志，存放到默认路径，使用指定日志类型
        /// </summary>
        /// <param name="msg">日志内容</param>
        /// <param name="logType">日志类型</param>
        public static void WriteLog(string msg, LogType logType)
        {
            WriteLog(msg, LogPath, logType);
        }

        /// <summary>
        /// 写普通日志，存放到指定路径，使用默认日志类型
        /// </summary>
        /// <param name="msg">日志内容</param>
        /// <param name="path">日志存放路径</param>
        public static void WriteLog(string msg, string path)
        {
            WriteLog(msg, path, LogType.Info);
        }

        /// <summary>
        /// 写普通日志，存放到指定路径，使用指定日志类型
        /// </summary>
        /// <param name="msg">日志内容</param>
        /// <param name="path">日志存放路径</param>
        /// <param name="logType">日志类型</param>
        public static void WriteLog(string msg, string path, LogType logType)
        {
            string fileName = path.Trim('\\') + "\\" + CreateFileName(logType);
            string logContext = FormatMsg(msg, logType);
            WriteFile(logContext, fileName);
        }

        #endregion

        #region 错误日志
        /// <summary>
        /// 写异常日志，存放到默认路径
        /// </summary>
        /// <param name="ex">异常类</param>
        /// <param name="isConsole">是否打印内容</param>
        public static void WriteError(Exception ex, bool isConsole = false)
        {
            if (isConsole)
            {
                PrintHelper.PrintLineWithTime(ex.Message, ConsoleColor.Red);
            }

            WriteError(ex, LogPath);
        }

        /// <summary>
        /// 写异常日志，存放到指定路径
        /// </summary>
        /// <param name="ex">异常类</param>
        /// <param name="path">日志存放路径</param>
        public static void WriteError(Exception ex, string path)
        {
            string errMsg = CreateErrorMeg(ex);
            WriteLog(errMsg, path, LogType.Error);
        }

        /// <summary>
        /// 写异常日志,并可选择打印到屏幕
        /// </summary>
        /// <param name="errMsg">错误内容</param>
        /// <param name="isConsole">是否打印内容到屏幕</param>
        public static void WriteError(string errMsg, bool isConsole = false)
        {
            if (isConsole)
            {
                PrintHelper.PrintLineWithTime(errMsg, ConsoleColor.Red);
            }

            WriteLog(errMsg, LogPath, LogType.Error);
        }
        #endregion

        #region 其他辅助方法

        /// <summary>
        /// 写日志到文件
        /// </summary>
        /// <param name="logContext">日志内容</param>
        /// <param name="fullName">文件名</param>
        private static void WriteFile(string logContext, string fullName)
        {
            FileStream fs = null;
            StreamWriter sw = null;

            int splitIndex = fullName.LastIndexOf('\\');
            if (splitIndex == -1) return;
            string path = fullName.Substring(0, splitIndex);

            if (!Directory.Exists(path)) Directory.CreateDirectory(path);

            try
            {
                if (!System.IO.File.Exists(fullName)) fs = new FileStream(fullName, FileMode.CreateNew);
                else fs = new FileStream(fullName, FileMode.Append);

                sw = new StreamWriter(fs);
                sw.WriteLine(logContext);
            }
            finally
            {
                if (sw != null)
                {
                    sw.Close();
                    sw.Dispose();
                }
                if (fs != null)
                {
                    fs.Close();
                    fs.Dispose();
                }
            }
        }

        /// <summary>
        /// 格式化日志，日志是默认类型
        /// </summary>
        /// <param name="msg">日志内容</param>
        /// <returns>格式化后的日志</returns>
        private static string FormatMsg(string msg)
        {
            return FormatMsg(msg, LogType.Info);
        }

        /// <summary>
        /// 格式化日志
        /// </summary>
        /// <param name="msg">日志内容</param>
        /// <param name="logType">日志类型</param>
        /// <returns>格式化后的日志</returns>
        private static string FormatMsg(string msg, LogType logType)
        {
            string result;
            string header = string.Format("[{0}][{1} {2}] ", logType.ToString(), DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString());
            result = header + msg;
            return result;
        }

        /// <summary>
        /// 从异常类中获取日志内容
        /// </summary>
        /// <param name="ex">异常类</param>
        /// <returns>日志内容</returns>
        private static string CreateErrorMeg(Exception ex)
        {
            string result = string.Empty;
            result += ex.Message + "\r\n";
            result += ex.StackTrace + "\r\n";
            return result;
        }

        /// <summary>
        /// 生成日志文件名
        /// </summary>
        /// <param name="logType">日志类型</param>
        /// <returns>日志文件名</returns>
        private static string CreateFileName(LogType logType)
        {
            string dataStr = DateTime.Now.ToString("yyyy-MM-dd HH");
            // if (logType != LogType.Info)
            dataStr = logType.ToString() + "_" + dataStr + ".log";
            return dataStr;
        }
        #endregion
    }

    /// <summary>
    /// 日志类型
    /// </summary>
    public enum LogType
    {
        /// <summary>
        /// 错误
        /// </summary>
        Error,
        /// <summary>
        /// 信息
        /// </summary>
        Info,
        /// <summary>
        /// 操作
        /// </summary>
        Option,
        /// <summary>
        /// 警告
        /// </summary>
        Warning
    }
}
