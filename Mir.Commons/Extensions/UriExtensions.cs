/******************************************************************
* 项目名称 ：Mir.Commons.Extensions 
* 项目描述 ： 
* 类 名 称 ：UriExtensions 
* 类 描 述 ： 
* CLR 版本 ：4.0.30319.42000 
* 版权所有 ：袁振峰
* 联系方式 ：http://www.ustuy.com/ 
******************************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace Mir.Commons.Extensions
{
    /// <summary>
    /// Uri扩展
    /// </summary>
    public static class UriExtensions
    {
        /// <summary>
        /// 把布尔值转换为小写字符串
        /// </summary>
        public static string GetUriFileName(this Uri value)
        {
            if (value != null && value.Segments != null && value.Segments.Length > 0)
                return value.Segments[value.Segments.Length - 1];
            else
                return "";
        }
    }
}
