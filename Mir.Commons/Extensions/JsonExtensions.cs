/******************************************************************
* 项目名称 ：Mir.Commons.Extensions 
* 项目描述 ： 
* 类 名 称 ：JsonExtensions 
* 类 描 述 ： 
* CLR 版本 ：4.0.30319.42000 
* 版权所有 ：袁振峰
* 联系方式 ：http://www.ustuy.com/ 
******************************************************************/
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Data;

namespace Mir.Commons.Extensions
{
    public static class JsonExtensions
    {
        /// <summary>
        /// 将Json字符串反序列化成.Net对象
        /// </summary>
        /// <param name="Json"></param>
        /// <returns></returns>
        public static object JsonToObject(this string Json)
        {
            return Json == null ? null : JsonConvert.DeserializeObject(Json);
        }

        /// <summary>
        /// 将Json字符串反序列化成动态对象
        /// </summary>
        /// <param name="Json"></param>
        /// <returns></returns>
        public static dynamic JsonToDynamic(this string Json)
        {
            return Json == null || Json == "" ? null : JsonConvert.DeserializeObject<dynamic>(Json);
        }

        /// <summary>
        /// 将对象转换成Json字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="datetimeformats">时间格式,默认"yyyy-MM-dd HH:mm:ss"</param>
        /// <returns></returns>
        public static string ObjectToJson(this object obj, string datetimeformats = "yyyy-MM-dd HH:mm:ss")
        {
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = datetimeformats };
            return JsonConvert.SerializeObject(obj, timeConverter);
        }

        /// <summary>
        /// 将Json字符串转换成泛型对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Json"></param>
        /// <returns></returns>
        public static T ToObject<T>(this string Json)
        {
            return Json == null ? default(T) : JsonConvert.DeserializeObject<T>(Json);
        }

        /// <summary>
        /// 将Json字符串转换成List泛型对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Json"></param>
        /// <returns></returns>
        public static List<T> ToList<T>(this string Json)
        {
            return Json == null ? new List<T>() : JsonConvert.DeserializeObject<List<T>>(Json);
        }

        /// <summary>
        /// 将Json字符串转换成DataTable
        /// </summary>
        /// <param name="Json"></param>
        /// <returns></returns>
        public static DataTable ToDataTable(this string Json)
        {
            return Json == null ? null : JsonConvert.DeserializeObject<DataTable>(Json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Json"></param>
        /// <returns></returns>
        public static JObject ToJObject(this string Json)
        {
            return Json == null ? JObject.Parse("{}") : JObject.Parse(Json.Replace("&nbsp;", ""));
        }
    }
}
