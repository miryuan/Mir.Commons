/******************************************************************
* 项目名称 ：Mir.Commons.Mqtt 
* 项目描述 ： 
* 类 名 称 ：EmqApiResult 
* 类 描 述 ： 
* CLR 版本 ：4.0.30319.42000 
* 版权所有 ：袁振峰
* 联系方式 ：http://www.ustuy.com/ 
******************************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace Mir.Commons.Mqtt
{
    /// <summary>
    /// EMQTT接口返回值
    /// </summary>
    public class EmqApiResult
    {
        /// <summary>
        /// 状态,0为正常返回
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// 结果或结果集合
        /// </summary>
        public Object Result { get; set; }
    }
}
