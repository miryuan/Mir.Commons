/******************************************************************
* 项目名称 ：Mir.Commons.Encrypt 
* 项目描述 ： 
* 类 名 称 ：MD5Helper 
* 类 描 述 ： 
* CLR 版本 ：4.0.30319.42000 
* 版权所有 ：袁振峰
* 联系方式 ：http://www.ustuy.com/ 
******************************************************************/
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Mir.Commons.Encrypt
{
    /// <summary>
    /// MD5帮助类
    /// </summary>
    public static class MD5Helper
    {
        /// <summary>
        /// 获得32位的MD5加密
        /// </summary>
        /// <param name="sourse">待加密字符串</param>
        /// <returns>32位字符串</returns>
        public static string MD5(string sourse)
        {
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] data = md5.ComputeHash(System.Text.Encoding.Default.GetBytes(sourse));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sb.Append(data[i].ToString("x2"));
            }
            return sb.ToString();
        }

        #region 文件MD5签名
        /// <summary>
        /// 对给定文件路径的文件加上标签
        /// </summary>
        /// <param name="path">文件位置</param>
        /// <returns>标签的值</returns>
        public static bool AddMD5(string path)
        {
            bool IsNeed = true;

            //已进行MD5处理
            if (CheckMD5(path))
                IsNeed = false;

            try
            {
                FileStream fsread = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                byte[] md5File = new byte[fsread.Length];
                //将文件流读取到Buffer中
                fsread.Read(md5File, 0, (int)fsread.Length);
                fsread.Close();

                if (IsNeed)
                {
                    //对Buffer中的字节内容算MD5
                    string result = MD5Buffer(md5File, 0, md5File.Length);
                    //将字符串转换成字节数组以便写人到文件中
                    byte[] md5 = System.Text.Encoding.ASCII.GetBytes(result);
                    FileStream fsWrite = new FileStream(path, FileMode.Open, FileAccess.ReadWrite);
                    //将文件，MD5值 重新写入到文件中。
                    fsWrite.Write(md5File, 0, md5File.Length);
                    fsWrite.Write(md5, 0, md5.Length);
                    fsWrite.Close();
                }
                else
                {
                    FileStream fsWrite = new FileStream(path, FileMode.Open, FileAccess.ReadWrite);
                    fsWrite.Write(md5File, 0, md5File.Length);
                    fsWrite.Close();
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 对给定路径的文件进行验证
        /// </summary>
        /// <param name="path">文件位置</param>
        /// <returns>是否加了标签或是否标签值与内容值一致</returns>
        public static bool CheckMD5(string path)
        {
            try
            {
                FileStream get_file = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                //读入文件
                byte[] md5File = new byte[get_file.Length];
                get_file.Read(md5File, 0, (int)get_file.Length);
                get_file.Close();

                //对文件除最后32位以外的字节计算MD5，这个32是因为标签位为32位。
                string result = MD5Buffer(md5File, 0, md5File.Length - 32);
                //读取文件最后32位，其中保存的就是MD5值
                string md5 = System.Text.Encoding.ASCII.GetString(md5File, md5File.Length - 32, 32);
                return result == md5;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 计算文件的MD5值
        /// </summary>
        /// <param name="path">文件位置</param>
        /// <returns>MD5字符串</returns>
        public static string FileMD5Buffer(string path)
        {
            try
            {
                FileStream get_file = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                //读入文件
                byte[] md5File = new byte[get_file.Length];
                return MD5Buffer(md5File, 0, md5File.Length);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 计算文件的MD5值
        /// </summary>
        /// <param name="MD5File">MD5签名文件字符数组</param>
        /// <param name="index">计算起始位置</param>
        /// <param name="count">计算终止位置</param>
        /// <returns>计算结果</returns>
        public static string MD5Buffer(byte[] MD5File, int index, int count)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider get_md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] hash_byte = get_md5.ComputeHash(MD5File, index, count);
            string result = System.BitConverter.ToString(hash_byte);

            result = result.Replace("-", "");
            return result;
        }
        #endregion
    }
}
