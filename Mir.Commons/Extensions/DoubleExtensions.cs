/******************************************************************
* 项目名称 ：Mir.Commons.Extensions 
* 项目描述 ： 
* 类 名 称 ：DoubleExtensions 
* 类 描 述 ： 
* CLR 版本 ：4.0.30319.42000 
* 版权所有 ：袁振峰
* 联系方式 ：http://www.ustuy.com/ 
******************************************************************/

namespace Mir.Commons.Extensions
{
    /// <summary>
    /// Double类型扩展
    /// </summary>
    public static class DoubleExtensions
    {
        /// <summary>
        /// 将Double转换成Int16
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static short ToInt16(this double obj) => short.Parse(obj.ToString());
        /// <summary>
        /// 将Double转换成整型
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static int ToInt32(this double obj, int defaultValue = 0)
        {
            try
            {
                return int.Parse(obj.ToString());
            }
            catch
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// 将Double转换成长整型
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static long ToInt64(this double obj) => long.Parse(obj.ToString());

        /// <summary>
        /// 转换成百分比字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="position">小数点后保留位数</param>
        /// <returns></returns>
        public static string ConvertToPercent(this double obj, ushort position)
        {
            return obj.ToString("p" + position).Replace(" ", "");
        }
    }
}
