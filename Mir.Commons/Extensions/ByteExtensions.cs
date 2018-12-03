/******************************************************************
* 项目名称 ：Mir.Commons.Extensions 
* 项目描述 ： 
* 类 名 称 ：ByteExtensions 
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
    /// 字节扩展类
    /// </summary>
    public static class ByteExtensions
    {
        /// <summary>
        /// Byte转换成十六进制
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public static string ToHex(this byte b)
        {
            return b.ToString("X2");
        }

        /// <summary>
        /// Byte[] 转换成十六进制
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string ToHex(this IEnumerable<byte> bytes)
        {
            var sb = new StringBuilder();
            foreach (var b in bytes)
            {
                sb.Append(b.ToString("X2"));
            }
            return sb.ToString();
        }

        /// <summary>
        /// Byte[] 转换为带空格分割的十六进制
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string ToHexWithSpace(this IEnumerable<byte> bytes)
        {
            var sb = new StringBuilder();
            foreach (var b in bytes)
            {
                sb.Append(b.ToString("X2"));
                sb.Append(" ");
            }
            return sb.ToString();
        }

        /// <summary>
        /// Byte[] 转换为 Base64字符串
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string ToBase64String(byte[] bytes)
        {
            return Convert.ToBase64String(bytes);
        }

        /// <summary>
        /// Byte[] 转换为 Int
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        public static int ToInt(this byte[] bytes, int startIndex = 0)
        {
            return BitConverter.ToInt32(bytes, startIndex);
        }

        /// <summary>
        /// Byte 转换为 Long
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        public static long ToLong(this byte[] bytes, int startIndex = 0)
        {
            return BitConverter.ToInt64(bytes, startIndex);
        }

        /// <summary>
        /// Byte 转换为 Char
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        public static char ToChar(this byte[] bytes, int startIndex = 0)
        {
            return BitConverter.ToChar(bytes, startIndex);
        }

        /// <summary>
        /// Byte 转换为 Float
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        public static float ToFloat(this byte[] bytes, int startIndex = 0)
        {
            return BitConverter.ToSingle(bytes, startIndex);
        }

        /// <summary>
        /// Byte 转换为 Double
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        public static double ToDouble(this byte[] bytes, int startIndex = 0)
        {
            return BitConverter.ToDouble(bytes, startIndex);
        }

        /// <summary>
        /// Byte 转换为 Boolean
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        public static bool ToBoolean(this byte[] bytes, int startIndex = 0)
        {
            return BitConverter.ToBoolean(bytes, startIndex);
        }

        /// <summary>
        /// Byte 转换为 String
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        public static string ToString(this byte[] bytes, int startIndex = 0)
        {
            return BitConverter.ToString(bytes, startIndex);
        }

        /// <summary>
        /// 使用编码转换Bytes为字符串
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string Decode(this byte[] bytes, Encoding encoding)
        {
            return encoding.GetString(bytes);
        }

        /// <summary>
        /// 使用指定算法计算Hash值
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="hashName"></param>
        /// <returns></returns>
        public static byte[] Hash(this byte[] bytes, string hashName = "ModSystem.Security.Cryptography.HashAlgorithm")
        {
            var algorithm = string.IsNullOrEmpty(hashName) ? HashAlgorithm.Create() : HashAlgorithm.Create(hashName);
            return algorithm != null ? algorithm.ComputeHash(bytes) : null;
        }

        // /// <summary>
        // /// 保存为文件
        // /// </summary>
        // /// <param name="bytes"></param>
        // /// <param name="path"></param>
        // public static void Save(this byte[] bytes, string path)
        // {
        //   File.WriteAllBytes(path, bytes);
        // }

        /// <summary>
        /// 转换为 MemoryStream
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static MemoryStream ToMemoryStream(this byte[] bytes)
        {
            return new MemoryStream(bytes);
        }
    }
}
