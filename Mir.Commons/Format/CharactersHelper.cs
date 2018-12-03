/******************************************************************
* 项目名称 ：Mir.Commons.Format 
* 项目描述 ： 
* 类 名 称 ：Characters 
* 类 描 述 ： 
* CLR 版本 ：4.0.30319.42000 
* 版权所有 ：袁振峰
* 联系方式 ：http://www.ustuy.com/ 
******************************************************************/
using System.Text;

namespace Mir.Commons.Format
{
    /// <summary>
    /// 文字帮助类
    /// </summary>
    public static class CharactersHelper
    {
        /// <summary>
        /// 获取中文字首字拼写
        /// </summary>
        /// <param name="chinese">中文文字</param>
        /// <returns></returns>
        public static string GetAcronym(string chinese)
        {
            int length = chinese.Length;
            StringBuilder acronym = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                acronym.Append(getSingle(chinese[i].ToString()));
            }
            return acronym.ToString(); ;
        }

        /// <summary>
        /// 获取单个字首字母 (GB2312)
        /// </summary>
        /// <param name="cnChar">中文文字</param>
        /// <returns></returns>
        private static string getSingle(string cnChar)
        {
            byte[] arrCN = Encoding.GetEncoding("GB2312").GetBytes(cnChar);
            if (arrCN.Length > 1)
            {
                int area = (short)arrCN[0];
                int pos = (short)arrCN[1];
                int code = (area << 8) + pos;
                int[] areacode = { 45217, 45253, 45761, 46318, 46826, 47010, 47297, 47614, 48119, 48119, 49062, 49324, 49896, 50371, 50614, 50622, 50906, 51387, 51446, 52218, 52698, 52698, 52698, 52980, 53689, 54481 };
                for (int i = 0; i < 26; i++)
                {
                    int max = 55290;
                    if (i != 25) max = areacode[i + 1];
                    if (areacode[i] <= code && code < max)
                    {
                        return Encoding.GetEncoding("GB2312").GetString(new byte[] { (byte)(65 + i) });
                    }
                }
                return string.Empty;
            }
            else return cnChar;
        }
    }
}
