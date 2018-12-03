/******************************************************************
* 项目名称 ：Mir.Commons.Encrypt 
* 项目描述 ： 
* 类 名 称 ：Base64Helper 
* 类 描 述 ： 
* CLR 版本 ：4.0.30319.42000 
* 版权所有 ：袁振峰
* 联系方式 ：http://www.ustuy.com/ 
******************************************************************/
using System;
using System.Text;

namespace Mir.Commons.Encrypt
{
    /// <summary>
    /// Base64 编码/解码帮助类
    /// </summary>
    public static class Base64Helper
    {
        /// <summary>
        /// Base64 编码,默认编码类型为UTF8
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string Encode(string source)
        {
            return EncodeBase64(source, Encoding.UTF8);
        }

        /// <summary>
        /// Base64 解码,默认编码类型为UTF8
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string Decode(string source)
        {
            return DecodeBase64(source, Encoding.UTF8);
        }

        /// <summary>
        /// Base64 编码
        /// </summary>
        /// <param name="source">要编码的字符串</param>
        /// <param name="encode">编码方式</param>
        /// <returns>返回编码后的字符串</returns>
        public static string EncodeBase64(string source, Encoding encode)
        {
            if (string.IsNullOrEmpty(source))
                return "";

            string result = "";
            byte[] bytes = encode.GetBytes(source);
            try
            {
                result = Convert.ToBase64String(bytes);
            }
            catch
            {
                result = source;
            }
            return result;
        }


        /// <summary>
        /// Base64 解码
        /// </summary>
        /// <param name="encode">解码方式</param>
        /// <param name="source">要解码的字符串</param>
        /// <returns>返回解码后的字符串</returns>
        public static string DecodeBase64(string source, Encoding encode)
        {
            if (string.IsNullOrEmpty(source))
                return "";

            string result = "";
            byte[] bytes = Convert.FromBase64String(source);
            try
            {
                result = encode.GetString(bytes);
            }
            catch
            {
                result = source;
            }
            return result;
        }
    }
}
