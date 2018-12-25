/******************************************************************
* 项目名称 ：Mir.Commons.Mqtt 
* 项目描述 ： 
* 类 名 称 ：EmqttHelper 
* 类 描 述 ： 
* CLR 版本 ：4.0.30319.42000 
* 版权所有 ：袁振峰
* 联系方式 ：http://www.ustuy.com/ 
******************************************************************/
using Mir.Commons.Extensions;
using Mir.Commons.Format;
using Mir.Commons.Net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Mir.Commons.Mqtt
{
    /// <summary>
    /// EMQTT 接口调用方式
    /// <para>
    /// 不知道如何调用,请先调用Help方法查看内容
    /// </para>
    /// </summary>
    public class EmqttHelper
    {
        /// <summary>
        /// 获取全部节点的基本信息
        /// </summary>
        /// <returns><see cref="EmqManagementNodesResult"/>集合</returns>
        public static EmqManagementNodesResult[] V2_Management_Nodes()
        {
            var apiResult = Get(EmqAPIs.v2_management_nodes);
            if (apiResult.Code == 0)
                return apiResult.Result.ToString().ToObject<EmqManagementNodesResult[]>();
            else
                return null;
        }

        /// <summary>
        /// 获取指定节点的基本信息
        /// </summary>
        /// <param name="nodeName">节点名称</param>
        /// <returns><see cref="EmqManagementNodeResult"/></returns>
        public static EmqManagementNodeResult V2_Management_Node(string nodeName)
        {
            var apiResult = Get(EmqAPIs.v2_management_node, nodeName);
            if (apiResult.Code == 0)
                return apiResult.Result.ToString().ToObject<EmqManagementNodeResult>();
            else
                return null;
        }

        /// <summary>
        /// 获取全部节点的运行统计(参数空)
        /// </summary>
        /// <returns></returns>
        public static EmqMonitoringStatsResult V2_Monitoring_Stats()
        {
            var apiResult = Get(EmqAPIs.v2_monitoring_stats);
            if (apiResult.Code == 0)
            {
                Dictionary<string, Dictionary<string, string>>[] dic = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>[]>(apiResult.Result.ToString());
                return new EmqMonitoringStatsResult(dic);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获取指定节点的监听器列表
        /// </summary>
        /// <param name="nodeName"></param>
        /// <returns></returns>
        public static EmqMonitoringListenerResult[] V2_Monitoring_Listener(string nodeName)
        {
            var apiResult = Get(EmqAPIs.v2_monitoring_listener, nodeName);
            if (apiResult.Code == 0)
            {
                return apiResult.Result.ToString().ToObject<EmqMonitoringListenerResult[]>();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获取集群内指定客户端的信息
        /// </summary>
        /// <param name="clientID"></param>
        /// <returns></returns>
        public static EmqNodesClientResult V2_Client(string clientID)
        {
            var apiResult = Get(EmqAPIs.v2_client, clientID);
            if (apiResult.Code == 0)
            {
                return apiResult.Result.ToString().ToObject<EmqNodesClientResult>();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获取指定节点的指定客户端连接列表
        /// </summary>
        /// <param name="nodeName"></param>
        /// <param name="clientID"></param>
        /// <returns></returns>
        public static EmqNodesClientResult V2_Nodes_Client(string nodeName, string clientID)
        {
            var apiResult = Get(EmqAPIs.v2_nodes_client, nodeName, clientID);
            if (apiResult.Code == 0)
            {
                return apiResult.Result.ToString().ToObject<EmqNodesClientResult>();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获取指定节点的客户端连接列表
        /// </summary>
        /// <param name="nodeName"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static EmqNodesClientsResult V2_Nodes_Clients(string nodeName, int pageIndex = 0, int pageSize = 30)
        {
            var apiResult = Get(EmqAPIs.v2_nodes_clients, nodeName, pageIndex.ToString(), pageSize.ToString());//需要用到分页"
            if (apiResult.Code == 0)
            {
                return apiResult.Result.ToString().ToObject<EmqNodesClientsResult>();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获取全部节点的监控数据
        /// </summary>
        /// <returns></returns>
        public static EmqMonitoringNodesResult[] V2_Monitoring_Nodes()
        {
            var apiResult = Get(EmqAPIs.v2_monitoring_nodes);
            if (apiResult.Code == 0)
            {
                return apiResult.Result.ToString().ToObject<EmqMonitoringNodesResult[]>();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获取指定节点的监控数据
        /// </summary>
        /// <param name="nodeName"></param>
        /// <returns></returns>
        public static EmqMonitoringNodeResult V2_Monitoring_Node(string nodeName)
        {
            var apiResult = Get(EmqAPIs.v2_monitoring_node, nodeName);
            if (apiResult.Code == 0)
            {
                return apiResult.Result.ToString().ToObject<EmqMonitoringNodeResult>();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获取节点的插件列表
        /// </summary>
        /// <param name="nodeName"></param>
        /// <returns></returns>
        public static EmqNodesPluginsResult V2_Nodes_Plugins(string nodeName)
        {
            var apiResult = Get(EmqAPIs.v2_nodes_plugins, nodeName);
            if (apiResult.Code == 0)
            {
                return apiResult.Result.ToString().ToObject<EmqNodesPluginsResult>();
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 获取指定节点的会话列表
        /// </summary>
        /// <param name="nodeName"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static EmqNodesSessionsResult V2_Nodes_Sessions(string nodeName, int pageIndex = 0, int pageSize = 30)
        {
            var apiResult = Get(EmqAPIs.v2_nodes_sessions, nodeName, pageIndex.ToString(), pageSize.ToString());//需要用到分页
            if (apiResult.Code == 0)
            {
                return apiResult.Result.ToString().ToObject<EmqNodesSessionsResult>();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获取节点上指定客户端的会话信息
        /// </summary>
        /// <param name="nodeName"></param>
        /// <param name="clientID"></param>
        /// <returns></returns>
        public static EmqNodesSessionResult V2_Nodes_Session(string nodeName, string clientID)
        {
            var apiResult = Get(EmqAPIs.v2_nodes_session, nodeName, clientID);//需要用到分页
            if (apiResult.Code == 0)
            {
                return apiResult.Result.ToString().ToObject<EmqNodesSessionResult>();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获取集群内指定客户端的会话信息
        /// </summary>
        /// <param name="clientID"></param>
        /// <returns></returns>
        public static EmqNodesSessionResult V2_Session(string clientID)
        {
            var apiResult = Get(EmqAPIs.v2_session, clientID);//需要用到分页
            if (apiResult.Code == 0)
            {
                return apiResult.Result.ToString().ToObject<EmqNodesSessionResult>();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获取指定节点上的订阅列表
        /// </summary>
        /// <param name="nodeName"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static EmqNodesSubscriptionsResult V2_Nodes_Subscriptions(string nodeName, int pageIndex = 0, int pageSize = 30)
        {
            var apiResult = Get(EmqAPIs.v2_nodes_subscriptions, nodeName, pageIndex.ToString(), pageSize.ToString());//需要用到分页
            if (apiResult.Code == 0)
            {
                return apiResult.Result.ToString().ToObject<EmqNodesSubscriptionsResult>();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获取节点上指定客户端的订阅信息
        /// </summary>
        /// <param name="nodeName"></param>
        /// <param name="clientID"></param>
        /// <returns></returns>
        public static EmqNodesSubscriptionResult V2_Nodes_Subscription(string nodeName, string clientID)
        {
            var apiResult = Get(EmqAPIs.v2_nodes_subscription, nodeName, clientID);
            if (apiResult.Code == 0)
            {
                return apiResult.Result.ToString().ToObject<EmqNodesSubscriptionResult>();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获取集群内指定客户端的订阅信息
        /// </summary>
        /// <param name="clientID"></param>
        /// <returns></returns>
        public static EmqNodesSubscriptionResult V2_Subscription(string clientID)
        {
            var apiResult = Get(EmqAPIs.v2_subscription, clientID);
            if (apiResult.Code == 0)
            {
                return apiResult.Result.ToString().ToObject<EmqNodesSubscriptionResult>();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获取集群主题信息
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static EmqRoutesResult V2_Routes(int pageIndex = 0, int pageSize = 30)
        {
            var apiResult = Get(EmqAPIs.v2_routes, pageIndex.ToString(), pageSize.ToString());
            if (apiResult.Code == 0)
            {
                return apiResult.Result.ToString().ToObject<EmqRoutesResult>();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static EmqMonitoringMetricsResult V2_Monitoring_Metrics()
        {
            var apiResult = Get(EmqAPIs.v2_monitoring_metrics);
            var dics = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>[]>(apiResult.Result.ToString());
            return new EmqMonitoringMetricsResult(dics);
        }

        /// <summary>
        /// EMQ访问地址
        /// </summary>
        public static string UrlBase { get; private set; }
        /// <summary>
        /// 账号
        /// </summary>
        public static string Account { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public static string Password { get; set; }

        /// <summary>
        /// 初始化EMQTT帮助类(V2版本)
        /// </summary>
        /// <param name="urlBase">EMQ主地址(http://192.168.0.1:18083/)</param>
        /// <param name="account"></param>
        /// <param name="password"></param>
        public static void InitV2(string urlBase, string account, string password)
        {
            bool flag = ValidateHelper.IsValidURL(urlBase);
            if (!flag) throw new Exception("EMQTT url error.");
            UrlBase = string.Format("{0}/", urlBase.TrimEnd('/')).ToLower();
            Account = account;
            Password = password;
        }

        /// <summary>
        /// 获取接口列表
        /// </summary>
        public static List<string> GetAPIList()
        {
            string resJson = HttpHelper.HttpGet(string.Format("{0}", UrlBase), account: Account, password: Password);
            var res = resJson.ToObject<EmqAPIListResult>();
            return res.paths;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="api"></param>
        /// <param name="pars"></param>
        /// <returns></returns>
        private static EmqApiResult Get(EmqAPIs api, params string[] pars)
        {
            string result = string.Empty;
            switch (api)
            {
                case EmqAPIs.v2_management_nodes:
                    result = GetResult("api/v2/management/nodes");
                    break;
                case EmqAPIs.v2_management_node:
                    result = GetResult(string.Format("api/v2/management/nodes/{0}", pars[0]));
                    break;
                case EmqAPIs.v2_monitoring_listener:
                    result = GetResult(string.Format("api/v2/monitoring/listeners/{0}", pars[0]));
                    break;
                //case EmqAPIs.v2_monitoring_listeners:
                //    result = GetResult(string.Format("api/v2/monitoring/listeners"));
                //    break;
                //case EmqAPIs.v2_monitoring_metric:
                //    result = GetResult(string.Format("api/v2/monitoring/metrics/{0}", pars[0]));
                //    break;
                case EmqAPIs.v2_monitoring_metrics:
                    result = GetResult(string.Format("api/v2/monitoring/metrics"));
                    break;
                case EmqAPIs.v2_monitoring_node:
                    result = GetResult(string.Format("api/v2/monitoring/nodes/{0}", pars[0]));
                    break;
                case EmqAPIs.v2_monitoring_nodes:
                    result = GetResult(string.Format("api/v2/monitoring/nodes"));
                    break;
                //case EmqAPIs.v2_monitoring_stat:
                //    result = GetResult(string.Format("api/v2/monitoring/stats/{0}", pars[0]));
                //    break;
                case EmqAPIs.v2_monitoring_stats:
                    result = GetResult(string.Format("api/v2/monitoring/stats"));
                    break;
                case EmqAPIs.v2_nodes_client:
                    result = GetResult(string.Format("api/v2/nodes/{0}/clients/{1}", pars[0], pars[1]));
                    break;
                case EmqAPIs.v2_nodes_clients:
                    {
                        int current_page = pars[1].ToInt(1);
                        int page_size = pars[2].ToInt(30);
                        result = GetResult(string.Format("api/v2/nodes/{0}/clients?curr_page={1}&page_size={2}", pars[0], current_page, page_size));
                    }
                    break;
                case EmqAPIs.v2_client:
                    result = GetResult(string.Format("api/v2/clients/{0}", pars[0]));
                    break;
                case EmqAPIs.v2_nodes_plugins:
                    result = GetResult(string.Format("api/v2/nodes/{0}/plugins", pars[0]));
                    break;
                case EmqAPIs.v2_nodes_session:
                    result = GetResult(string.Format("api/v2/nodes/{0}/sessions/{1}", pars[0], pars[1]));
                    break;
                case EmqAPIs.v2_nodes_sessions:
                    {
                        int current_page = pars[1].ToInt(1);
                        int page_size = pars[2].ToInt(30);
                        result = GetResult(string.Format("api/v2/nodes/{0}/sessions?curr_page={1}&page_size={2}", pars[0], current_page, page_size));
                    }
                    break;
                case EmqAPIs.v2_session:
                    result = GetResult(string.Format("api/v2/sessions/{0}", pars[0]));
                    break;
                case EmqAPIs.v2_nodes_subscription:
                    result = GetResult(string.Format("api/v2/nodes/{0}/subscriptions/{1}", pars[0], pars[1]));
                    break;
                case EmqAPIs.v2_nodes_subscriptions:
                    {
                        int current_page = pars[1].ToInt(1);
                        int page_size = pars[2].ToInt(30);
                        result = GetResult(string.Format("api/v2/nodes/{0}/subscriptions?curr_page={1}&page_size={2}", pars[0], current_page, page_size));
                    }
                    break;
                case EmqAPIs.v2_subscription:
                    result = GetResult(string.Format("api/v2/subscriptions/{0}", pars[0]));
                    break;
                //case EmqAPIs.v2_route:
                //    result = GetResult(string.Format("api/v2/routes/{0}", pars[0]));
                //    break;
                case EmqAPIs.v2_routes:
                    {
                        int current_page = pars[0].ToInt(1);
                        int page_size = pars[0].ToInt(30);
                        result = GetResult(string.Format("api/v2/routes?curr_page={0}&page_size={1}", current_page, page_size));
                    }
                    break;
                default:
                    return new EmqApiResult();
            }

            return result.ToObject<EmqApiResult>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actionUrl"></param>
        /// <returns></returns>
        private static string GetResult(string actionUrl)
        {
            return HttpHelper.HttpGet(string.Format("{0}{1}", UrlBase, actionUrl), account: Account, password: Password);
        }

        ///// <summary>
        ///// 获取全部节点的基本信息
        ///// <para>api/v2/management/nodes</para>
        ///// </summary>
        //public static EmqApiResult ManagementNodes()
        //{
        //    string resJson = HttpHelper.HttpGet(string.Format("{0}api/v2/management/nodes", UrlBase), account: Account, password: Password);
        //    return resJson.ToObject<EmqApiResult>();
        //}
    }
}
