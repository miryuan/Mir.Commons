/******************************************************************
* 项目名称 ：UnitTest 
* 项目描述 ： 
* 类 名 称 ：UnitTest_Log 
* 类 描 述 ： 
* CLR 版本 ：4.0.30319.42000 
* 版权所有 ：袁振峰
* 联系方式 ：http://www.ustuy.com/ 
******************************************************************/
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mir.Commons.Log;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace UnitTest
{
    [TestClass]
    public class UnitTest_Log
    {
        [TestMethod]
        public void TestLogFile()
        {
            //可以设置,也可以不设置,默认输出位置为项目坐在文件夹的Log目录中
            //LogFileHelper.LogPath = "D:\\"; 

            LogFileHelper.WriteLog("这是输出的内容!!!!", true);
            LogFileHelper.WriteLog("这是输出的内容!!!!", LogType.Info);
            LogFileHelper.WriteLog("这是输出的内容!!!!", "D:\\Log\\", LogType.Info);
        }

        [TestMethod]
        public void TestPrint()
        {
            //控制台输出

            //输出空白行
            PrintHelper.OutLine();
            //输出内容
            PrintHelper.Print("不换行输出", ConsoleColor.Red);
            PrintHelper.PrintLine("换行输出", ConsoleColor.Green);
            PrintHelper.PrintLineWithTime("这里会自动输出时间,然后才是内容", ConsoleColor.Yellow);
        }
    }
}
