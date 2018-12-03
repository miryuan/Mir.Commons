/******************************************************************
* 项目名称 ：Mir.Commons.Extensions 
* 项目描述 ： 
* 类 名 称 ：DateTimeExtensions 
* 类 描 述 ： 
* CLR 版本 ：4.0.30319.42000 
* 版权所有 ：袁振峰
* 联系方式 ：http://www.ustuy.com/ 
******************************************************************/
using System;
using System.Linq;

namespace Mir.Commons.Extensions
{
    /// <summary>
    /// 日期/时间扩展类
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Unix时间起始时间
        /// </summary>
        public static readonly DateTime StarTime = new DateTime(1970, 1, 1);

        /// <summary>
        /// 常用日期格式
        /// </summary>
        public static readonly string CommonDateFormat = "yyyy-MM-dd HH:mm:ss.fff";

        /// <summary>
        /// 周未定义
        /// </summary>
        public static readonly DayOfWeek[] Weekend = { DayOfWeek.Saturday, DayOfWeek.Sunday };

        /// <summary>
        /// 获取从Unix起始时间到给定时间的毫秒数
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static long GetMillisecondsSince1970(this DateTime datetime)
        {
            var ts = datetime.Subtract(StarTime);
            return (long)ts.TotalMilliseconds;
        }

        /// <summary>
        /// 获取从Unix起始时间到给定时间的秒数
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static long GetSecondsSince1970(this DateTime datetime)
        {
            var ts = datetime.Subtract(StarTime);
            return (long)ts.TotalSeconds;
        }

        /// <summary>
        /// 明天
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime Tomorrow(this DateTime date)
        {
            return date.AddDays(1);
        }

        /// <summary>
        /// 昨天
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime Yesterday(this DateTime date)
        {
            return date.AddDays(-1);
        }

        /// <summary>
        /// 常用日期格式化字符串
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string ToCommonFormat(this DateTime date)
        {
            return date.ToString(CommonDateFormat);
        }

        /// <summary>
        /// 是否是周未
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsWeekend(this DateTime date)
        {
            return Weekend.Any(p => p == date.DayOfWeek);
        }

        /// <summary>
        /// 是否是工作日
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsWeekDay(this DateTime date)
        {
            return !date.IsWeekend();
        }

        /// <summary>
        /// 给定月份的第1天
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime GetFirstDayOfMonth(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1);
        }

        /// <summary>
        /// 给定月份的最后1天
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime GetLastDayOfMonth(this DateTime date)
        {
            return date.GetFirstDayOfMonth().AddMonths(1).AddDays(-1);
        }

        /// <summary>
        /// 给定日期所在月份第1个星期几所对应的日期
        /// </summary>
        /// <param name="date">给定日期</param>
        /// <param name="dayOfWeek">星期几</param>
        /// <returns>所对应的日期</returns>
        public static DateTime GetFirstWeekDayOfMonth(this DateTime date, DayOfWeek dayOfWeek)
        {
            var dt = date.GetFirstDayOfMonth();
            while (dt.DayOfWeek != dayOfWeek)
                dt = dt.AddDays(1);

            return dt;
        }

        /// <summary>
        /// 给定日期所在月份最后1个星期几所对应的日期
        /// </summary>
        /// <param name="date">给定日期</param>
        /// <param name="dayOfWeek">星期几</param>
        /// <returns>所对应的日期</returns>
        public static DateTime GetLastWeekDayOfMonth(this DateTime date, DayOfWeek dayOfWeek)
        {
            var dt = date.GetLastDayOfMonth();
            while (dt.DayOfWeek != dayOfWeek)
                dt = dt.AddDays(-1);

            return dt;
        }

        /// <summary>
        /// 早于给定日期
        /// </summary>
        /// <param name="date"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        public static bool IsBefore(this DateTime date, DateTime other)
        {
            return date.CompareTo(other) < 0;
        }

        /// <summary>
        /// 晚于给定日期
        /// </summary>
        /// <param name="date"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        public static bool IsAfter(this DateTime date, DateTime other)
        {
            return date.CompareTo(other) > 0;
        }

        /// <summary>
        /// 给定日期最后一刻,精确到23:59:59.999
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime EndTimeOfDay(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 23, 59, 59, 999);
        }

        /// <summary>
        ///  给定日期开始一刻,精确到0:0:0.0
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime StartTimeOfDay(this DateTime date)
        {
            return date.Date;
        }

        /// <summary>
        ///  给定日期的中午,精确到12:0:0.0
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime NoonOfDay(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 12, 0, 0);
        }

        /// <summary>
        /// 当前日期与给定日期是否是同一天
        /// </summary>
        /// <param name="date">当前日期</param>
        /// <param name="dateToCompare">给定日期</param>
        /// <returns></returns>
        public static bool IsDateEqual(this DateTime date, DateTime dateToCompare)
        {
            return (date.Date == dateToCompare.Date);
        }

        /// <summary>
        /// 判断是否为今天
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsToday(this DateTime date)
        {
            return (date.Date == DateTime.Now.Date);
        }

        /// <summary>
        /// 给定日期所在月份共有多少天
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static int GetCountDaysOfMonth(this DateTime date)
        {
            return date.GetLastDayOfMonth().Day;
        }

        /// <summary>
        /// 周日
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="weeks">上周-1 下周+1 本周0</param>
        /// <returns></returns>
        public static string GetSunday(this DateTime dt, int? weeks = 0)
        {
            int week = weeks ?? 0;
            return dt.AddDays(Convert.ToDouble((0 - Convert.ToInt16(dt.DayOfWeek))) + 7 * week).ToShortDateString();
        }

        /// <summary>
        /// 周六
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="weeks">上周-1 下周+1 本周0</param>
        /// <returns></returns>
        public static string GetSaturday(this DateTime dt, int? weeks = 0)
        {
            int week = weeks ?? 0;
            return dt.AddDays(Convert.ToDouble((6 - Convert.ToInt16(dt.DayOfWeek))) + 7 * week).ToShortDateString();
        }

        /// <summary>
        /// 给定日期的年度第一天
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="years">上年度-1 下年度+1</param>
        /// <returns></returns>
        public static string GetFirstDayOfYear(this DateTime dt, int? years)
        {
            int year = years ?? 0;
            return DateTime.Parse(dt.ToString("yyyy-01-01")).AddYears(year).ToShortDateString();
        }

        /// <summary>
        /// 给定日期的年度最后一天
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="years">上年度0 本年度1 下年度2</param>
        /// <returns></returns>
        public static string GetLastDayOfYear(this DateTime dt, int? years)
        {
            int year = years ?? 0;
            return DateTime.Parse(dt.ToString("yyyy-01-01")).AddYears(year).AddDays(-1).ToShortDateString();
        }

        /// <summary>
        /// 给定日期的季度第一天
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="quarters">上季度-1 下季度+1</param>
        /// <returns></returns>
        public static string GetFirstDayOfQuarter(this DateTime dt, int? quarters)
        {
            int quarter = quarters ?? 0;
            return dt.AddMonths(quarter * 3 - ((dt.Month - 1) % 3)).ToString("yyyy-MM-01");
        }

        /// <summary>
        /// 给定日期的季度最后一天
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="quarters">上季度0 本季度1 下季度2</param>
        /// <returns></returns>
        public static string GetLastDayOfQuarter(this DateTime dt, int? quarters)
        {
            int quarter = quarters ?? 0;
            return DateTime.Parse(dt.AddMonths(quarter * 3 - ((dt.Month - 1) % 3)).ToString("yyyy-MM-01")).AddDays(-1).ToShortDateString();
        }

        /// <summary>
        /// 获取给定日期的中文星期名称
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string GetDayOfWeekCN(this DateTime dt)
        {
            string[] Day = new string[] { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
            return Day[Convert.ToInt16(dt.DayOfWeek)];
        }

        /// <summary>
        /// 获取星期数字形式,周一开始
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static int GetDayOfWeekNum(this DateTime dt)
        {
            int day = (Convert.ToInt16(dt.DayOfWeek) == 0) ? 7 : Convert.ToInt16(dt.DayOfWeek);
            return day;
        }
    }
}
