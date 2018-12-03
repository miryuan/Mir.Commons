/******************************************************************
* 项目名称 ：Mir.Commons.File 
* 项目描述 ： 
* 类 名 称 ：XmlConvertor 
* 类 描 述 ： 
* CLR 版本 ：4.0.30319.42000 
* 版权所有 ：袁振峰
* 联系方式 ：http://www.ustuy.com/ 
******************************************************************/
using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Mir.Commons.File
{
    /// <summary>
    /// 此类提供了一些用于转换XML和对象的实用方法
    /// </summary>
    public static class XmlHelper
    {
        /// <summary>
        /// 将XML字符串转换为指定的对象
        /// </summary>
        /// <param name="xml">XML字符串</param>
        /// <param name="type">待转类型</param>
        /// <returns>对象从XML字符串反序列化</returns>
        public static object XmlToObject(string xml, Type type)
        {
            if (null == xml)
            {
                throw new ArgumentNullException("空的XML");
            }
            if (null == type)
            {
                throw new ArgumentNullException("空类型");
            }

            object obj = null;
            XmlSerializer serializer = new XmlSerializer(type);
            StringReader strReader = new StringReader(xml);
            XmlReader reader = new XmlTextReader(strReader);

            try
            {
                obj = serializer.Deserialize(reader);
            }
            catch (InvalidOperationException ie)
            {
                throw new InvalidOperationException("不能将XML转换为对象", ie);
            }
            finally
            {
                reader.Close();
            }
            return obj;
        }

        /// <summary>
        /// 将对象转换为XML字符串
        /// </summary>
        /// <param name="obj">要序列化的对象</param>
        /// <param name="toBeIndented">是否紧密排列</param>
        /// <returns>XML String</returns>
        public static string ObjectToXml(object obj, bool toBeIndented)
        {
            if (null == obj)
            {
                throw new ArgumentNullException("对象不能为空");
            }
            UTF8Encoding encoding = new UTF8Encoding(false);
            XmlSerializer serializer = new XmlSerializer(obj.GetType());
            MemoryStream stream = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(stream, encoding)
            {
                Formatting = (toBeIndented ? Formatting.Indented : Formatting.None)
            };

            try
            {
                serializer.Serialize(writer, obj);
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException("无法将对象转换为XML.");
            }
            finally
            {
                writer.Close();
            }

            string xml = encoding.GetString(stream.ToArray());
            return xml;
        }
    }
}
