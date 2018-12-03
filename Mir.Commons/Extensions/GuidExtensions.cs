/******************************************************************
* 项目名称 ：Mir.Commons.Extensions 
* 项目描述 ： 
* 类 名 称 ：GuidExtensions 
* 类 描 述 ： 
* CLR 版本 ：4.0.30319.42000 
* 版权所有 ：袁振峰
* 联系方式 ：http://www.ustuy.com/ 
******************************************************************/
using System;

namespace Mir.Commons.Extensions
{
    /// <summary>
    /// GUID扩展
    /// </summary>
    public static class GuidExtensions
    {
        /// <summary>
        /// 生成字符串示例:E0A953C3EE6040EAA9FAE2B667060E09
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string NewGuid_N(this Guid obj)
        {
            return obj.ToString("N").ToUpper();
        }

        /// <summary>
        /// 生成字符串示例:e0a953c3ee6040eaa9fae2b667060e09
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string NewGuid_n(this Guid obj)
        {
            return obj.ToString("N");
        }

        /// <summary>
        /// 生成字符串示例:E0A953C3-EE60-40EA-A9FA-E2B667060E09
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string NewGuid_D(this Guid obj)
        {
            return obj.ToString("D").ToUpper();
        }

        /// <summary>
        /// 生成字符串示例:e0a953c3-ee60-40ea-a9fa-e2b667060e09
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string NewGuid_d(this Guid obj)
        {
            return obj.ToString("D");
        }

        /// <summary>
        /// 生成字符串示例:{E0A953C3-EE60-40EA-A9FA-E2B667060E09}
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string NewGuid_B(this Guid obj)
        {
            return obj.ToString("B").ToUpper();
        }

        /// <summary>
        /// 生成字符串示例:{e0a953c3-ee60-40ea-a9fa-e2b667060e09}
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string NewGuid_b(this Guid obj)
        {
            return obj.ToString("B");
        }

        /// <summary>
        /// 生成字符串示例:(E0A953C3-EE60-40EA-A9FA-E2B667060E09)
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string NewGuid_P(this Guid obj)
        {
            return obj.ToString("P").ToUpper();
        }

        /// <summary>
        /// 生成字符串示例:(e0a953c3-ee60-40ea-a9fa-e2b667060e09)
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string NewGuid_p(this Guid obj)
        {
            return obj.ToString("P");
        }

        /// <summary>
        /// 生成字符串示例:{0x3fa412e3,0x8356,0x428f,{0xaa,0x34,0xb7,0x40,0xda,0xaf,0x45,0x6f}}
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string NewGuid_x(this Guid obj)
        {
            return obj.ToString("X");
        }
    }
}
