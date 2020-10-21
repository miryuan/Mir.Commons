/******************************************************************
* 项目名称 ：Mir.Commons.Extensions 
* 项目描述 ： 
* 类 名 称 ：BooleanExtensions 
* 类 描 述 ： 
* CLR 版本 ：4.0.30319.42000 
* 版权所有 ：袁振峰
* 联系方式 ：http://www.ustuy.com/ 
******************************************************************/
using System;

namespace Mir.Commons.Extensions
{
    /// <summary>
    /// 布尔值<see cref="bool"/>类型的扩展辅助操作类
    /// </summary>
    public static class BooleanExtensions
    {
        /// <summary>
        /// 把布尔值转换为小写字符串
        /// </summary>
        public static string ToLower(this bool value)
        {
            return value.ToString().ToLower();
        }

        /// <summary>
        /// 把布尔值转换为大写字符串
        /// </summary>
        public static string ToUpper(this bool value)
        {
            return value.ToString().ToUpper();
        }
    }
}
