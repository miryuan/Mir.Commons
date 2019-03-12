/******************************************************************
* 项目名称 ：Mir.Commons.Extensions 
* 项目描述 ： 
* 类 名 称 ：StringExtensions 
* 类 描 述 ： 
* CLR 版本 ：4.0.30319.42000 
* 版权所有 ：袁振峰
* 联系方式 ：http://www.ustuy.com/ 
******************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Mir.Commons.Extensions
{
    /// <summary>
    /// String扩展
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// 提取字符串中的数字
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ExtractDecimal(this string value)
        {
            StringBuilder result = new StringBuilder();
            foreach (char c in value)
            {
                if ((Convert.ToInt32(c) >= 48 && Convert.ToInt32(c) <= 57) || Convert.ToInt32(c) == 46)
                {
                    result.Append(c);
                }
            }
            return result.ToString();
        }

        /// <summary>
        /// 将字符串转换成Int32
        /// </summary>
        /// <param name="value">待转换的字符串</param>
        /// <returns>Int32</returns>
        public static int ToInt(this string value)
        {
            return int.Parse(value);
        }

        /// <summary>
        /// 将字符串转换成Int32
        /// </summary>
        /// <param name="value">待转换的字符串</param>
        /// <param name="defaultValue">转换失败时返回的默认值</param>
        /// <returns>Int32</returns>
        public static int ToInt(this string value, int defaultValue)
        {
            var result = defaultValue;
            return int.TryParse(value, out result) ? result : defaultValue;
        }

        /// <summary>
        /// 将字符串转换成Int64
        /// </summary>
        /// <param name="value">待转换的字符串</param>
        /// <param name="defaultValue">转换失败时返回的默认值</param>
        /// <returns>Int64</returns>
        public static long ToLong(this string value, long defaultValue)
        {
            var result = defaultValue;
            return long.TryParse(value, out result) ? result : defaultValue;
        }

        /// <summary>
        /// 将字符串转换成UInt
        /// </summary>
        /// <param name="value">待转换的字符串</param>
        /// <param name="defaultValue">转换失败时返回的默认值</param>
        /// <returns>Uint</returns>
        public static uint ToUint(this string value, uint defaultValue)
        {
            var result = defaultValue;
            return uint.TryParse(value, out result) ? result : defaultValue;
        }

        /// <summary>
        /// 将字符串转换成Short
        /// </summary>
        /// <param name="value">待转换的字符串</param>
        /// <param name="defaultValue">转换失败时返回的默认值</param>
        /// <returns>short</returns>
        public static short ToShort(this string value, short defaultValue)
        {
            var result = defaultValue;
            return short.TryParse(value, out result) ? result : defaultValue;
        }

        /// <summary>
        /// 将字符串转换成Int32
        /// </summary>
        /// <param name="value">待转换的字符串</param>
        /// <returns>Int32 or Null</returns>
        public static int? ToNullableInt(this string value)
        {
            if (string.IsNullOrEmpty(value) || !int.TryParse(value, out int result))
            {
                return null;
            }
            return result;
        }

        /// <summary>
        /// 将字符串转换成非Null字符串
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static string ToString(this string value, string defaultValue)
        {
            if (string.IsNullOrEmpty(value))
            {
                return defaultValue;
            }
            return value;
        }

        /// <summary>
        /// 将字符串转换成十进制数
        /// </summary>
        /// <param name="value">待转换的字符串</param>
        /// <returns>十进制</returns>
        public static decimal ToDecimal(this string value)
        {
            return decimal.Parse(value);
        }

        /// <summary>
        /// 将字符串转换成十进制数
        /// </summary>
        /// <param name="value">待转换的字符串</param>
        /// <param name="defaultValue">转换失败时的默认值</param>
        /// <returns>十进制</returns>
        public static decimal ToDecimal(this string value, decimal defaultValue)
        {
            var result = defaultValue;
            return decimal.TryParse(value, out result) ? result : defaultValue;
        }

        /// <summary>
        /// 将字符串四舍五入转换成十进制数
        /// </summary>
        /// <param name="value">待转换的字符串</param>
        /// <param name="defaultValue">转换失败时的默认值</param>
        /// <param name="decimals">返回值中的小数数字</param>
        /// <returns>十进制</returns>
        public static decimal ToRoundDecimal(this string value, decimal defaultValue, int decimals)
        {
            var result = defaultValue;
            result = Math.Round(decimal.TryParse(value, out result) ? result : defaultValue, decimals);
            return result;
        }

        /// <summary>
        /// 将字符型数值转换成可为null数值型
        /// </summary>
        /// <param name="value">字符型数值</param>
        /// <returns></returns>
        public static decimal? ToNullableDecimal(this string value)
        {
            if (string.IsNullOrEmpty(value) || !decimal.TryParse(value, out decimal result))
            {
                return null;
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static short? ToNullableShort(this string value)
        {
            if (string.IsNullOrEmpty(value) || !short.TryParse(value, out short result))
            {
                return null;
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTime? ToNullableDateTime(this string value)
        {
            if (DateTime.TryParse(value, out DateTime result))
            {
                return result;
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this string value)
        {
            return DateTime.Parse(value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte? ToNullableByte(this string value)
        {

            if (string.IsNullOrEmpty(value) || !byte.TryParse(value, out byte result))
            {
                return null;
            }

            return result;
        }

        /// <summary>
        /// 将String转换成Byte[]
        /// </summary>
        /// <param name="text">要转换的字符串</param>
        public static byte[] StringToBytes(this string text)
        {
            return Encoding.Default.GetBytes(text);
        }

        /// <summary>
        /// 使用指定字符集将String转换成Byte[]
        /// </summary>
        /// <param name="text">要转换的字符串</param>
        /// <param name="encoding">字符编码</param>
        public static byte[] StringToBytes(this string text, Encoding encoding)
        {
            return encoding.GetBytes(text);
        }

        /// <summary>
        /// 将byte[]转换成string
        /// </summary>
        /// <param name="bytes">要转换的字节数组</param>
        public static string BytesToString(byte[] bytes)
        {
            return Encoding.Default.GetString(bytes);
        }

        /// <summary>
        /// 使用指定字符集将byte[]转换成string
        /// </summary>
        /// <param name="bytes">要转换的字节数组</param>
        /// <param name="encoding">字符编码</param>
        public static string BytesToString(byte[] bytes, Encoding encoding)
        {
            return encoding.GetString(bytes);
        }

        /// <summary>
        /// 将字符型bool值转换成可为null布尔型
        /// </summary>
        /// <param name="value">字符型bool值</param>
        /// <returns></returns>
        public static bool? ToNullableBool(this string value)
        {
            if (string.IsNullOrEmpty(value) || !bool.TryParse(value, out bool result))
            {
                return null;
            }

            return result;
        }

        /// <summary>
        /// 将字符串转换成Boolean类型
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool ToBool(this string value)
        {
            return bool.Parse(value);
        }

        /// <summary>
        /// 将字符串转换成Boolean类型
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue">转换失败时返回的默认值</param>
        /// <returns></returns>
        public static bool ToBool(this string value, bool defaultValue = false)
        {
            if (value == null) return defaultValue;

            bool result = defaultValue;
            if (bool.TryParse(value, out result))
                return result;
            else
                return defaultValue;
        }

        /// <summary>
        /// 将字符串转换成对应的枚举类型
        /// </summary>
        /// <param name="value"></param>
        /// <typeparam name="T">枚举类型</typeparam>
        /// <returns>枚举值</returns>
        public static T ToEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }

        /// <summary>
        /// 将字符串转换成对应的枚举类型
        /// </summary>
        /// <param name="value"></param>
        /// <typeparam name="T">枚举类型</typeparam>
        /// <param name="defaultValue">转换失败时输出的默认值</param>
        /// <returns>枚举值</returns>
        public static T ToEnum<T>(this string value, T defaultValue)
        {
            try
            {
                return (T)Enum.Parse(typeof(T), value);
            }
            catch { }

            return defaultValue;
        }

        /// <summary>
        /// MD5加密,不可逆
        /// </summary>
        /// <param name="value">待加密字符串</param>
        /// <returns></returns>
        public static string ToMD5(this string value)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = System.Text.Encoding.Unicode.GetBytes(value);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x");
            }

            return byte2String;
        }

        /// <summary>
        /// 获取文件字符串的扩展名
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string FindExtensionName(this string value)
        {
            string ret = string.Empty;
            if (value.Contains('.'))
            {
                string[] temp = value.Split('.');
                ret = temp[temp.Length - 1];
            }
            return ret;
        }

        /// <summary>
        /// 获取Uri字符串的文件扩展名
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string FindUriExtensionName(this string str)
        {
            Uri value = new Uri(str);
            if (value != null && value.Segments != null && value.Segments.Length > 0)
                return value.Segments[value.Segments.Length - 1];
            else
                return "";
        }

        /// <summary>
        /// 将字符串集合转换成List
        /// </summary>
        /// <param name="arrs"></param>
        /// <returns></returns>
        public static List<string> ToList(this string[] arrs)
        {
            if (arrs == null || arrs.Length == 0) return new List<string>();

            List<string> li = new List<string>();
            li.AddRange(arrs);
            return li;
        }
    }
}
