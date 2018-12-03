/******************************************************************
* 项目名称 ：Mir.Commons.Log 
* 项目描述 ： 
* 类 名 称 ：PrintHelper 
* 类 描 述 ： 
* CLR 版本 ：4.0.30319.42000 
* 版权所有 ：袁振峰
* 联系方式 ：http://www.ustuy.com/ 
******************************************************************/
using System;

namespace Mir.Commons.Log
{
    /// <summary>
    /// 控制台输出帮助类
    /// </summary>
    public static class PrintHelper
    {
        /// <summary>
        /// 控制台输出文本,输出结束后不换行
        /// </summary>
        /// <param name="message">文本内容</param>
        /// <param name="color">文本颜色,默认灰色</param>
        public static void Print(string message, ConsoleColor color = ConsoleColor.Gray)
        {
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ResetColor();
        }

        /// <summary>
        /// 控制台输出文本,输出结束后进行换行
        /// </summary>
        /// <param name="message">文本内容</param>
        /// <param name="color">文本颜色,默认灰色</param>
        public static void PrintLine(string message, ConsoleColor color = ConsoleColor.Gray)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        /// <summary>
        /// 控制台输出包含时间的文本,输出结束后进行换行
        /// </summary>
        public static void PrintLineWithTime(string message, ConsoleColor color = ConsoleColor.Gray)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(DateTime.Now.ToString("HH:mm:ss:fff\t") + message);
            Console.ResetColor();
        }

        /// <summary>
        /// 换行
        /// </summary>
        public static void OutLine()
        {
            Console.WriteLine();
        }
    }
}
