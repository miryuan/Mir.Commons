/******************************************************************
* 项目名称 ：Mir.Commons.Other 
* 项目描述 ： 
* 类 名 称 ：WatchingTime 
* 类 描 述 ： 
* CLR 版本 ：4.0.30319.42000 
* 版权所有 ：袁振峰
* 联系方式 ：http://www.ustuy.com/ 
******************************************************************/
using System.Diagnostics;

namespace Mir.Commons.Other
{
    /// <summary>
    /// 运行时计时小工具
    /// </summary>
    public class WatchingTime
    {
        private Stopwatch _watch { get; set; }
        public WatchingTime() => _watch = new Stopwatch();

        /// <summary>
        /// 开始计时,开始前会重置计时器
        /// </summary>
        public void WatchStart()
        {
            _watch.Reset();
            _watch.Start();
        }

        /// <summary>
        /// 计时暂停
        /// </summary>
        public void WatchPause()
        {
            _watch.Stop();
        }

        /// <summary>
        /// 重起计时
        /// </summary>
        public void WatchRestart()
        {
            _watch.Restart();
        }

        /// <summary>
        /// 结束计时,返回运行时间并重置计时
        /// </summary>
        /// <returns>Double</returns>
        public double WatchStop()
        {
            _watch.Stop();
            double costtime = _watch.ElapsedMilliseconds;
            _watch.Reset();
            return costtime;
        }

        /// <summary>
        /// 获取当前运行时间
        /// </summary>
        /// <returns>Double</returns>
        public double GetCostTime()
        {
            return _watch.ElapsedMilliseconds;
        }
    }
}
