/******************************************************************
* 项目名称 ：Mir.Commons.Mqtt 
* 项目描述 ： 
* 类 名 称 ：EmqAPIs 
* 类 描 述 ： 
* CLR 版本 ：4.0.30319.42000 
* 版权所有 ：袁振峰
* 联系方式 ：http://www.ustuy.com/ 
******************************************************************/

namespace Mir.Commons.Mqtt
{
    /// <summary>
    /// 接口列表
    /// </summary>
    public enum EmqAPIs
    {
        /// <summary>
        /// 获取全部节点的基本信息(参数空)
        /// <see cref="EmqManagementNodesResult"/>
        /// </summary>
        v2_management_nodes,
        /// <summary>
        /// 获取指定节点的基本信息(带一个参数:节点名称)
        /// <see cref="EmqMonitoringNodeResult"/>
        /// </summary>
        v2_management_node,
        /// <summary>
        /// 获取全部节点的监控数据(参数空)
        /// <see cref="EmqMonitoringNodesResult"/>
        /// </summary>
        v2_monitoring_nodes,
        /// <summary>
        /// 获取指定节点的监控数据(带一个参数:节点名称)
        /// <see cref="EmqManagementNodeResult"/>
        /// </summary>
        v2_monitoring_node,
        /// <summary>
        /// 获取指定节点的客户端连接列表(带一个参数:节点名称,显示第几页,页面大小
        /// <see cref="EmqNodesClientsResult"/>
        /// </summary>
        v2_nodes_clients,
        /// <summary>
        /// 获取指定节点的指定客户端连接列表(带两个参数:节点名称,客户端ID)
        /// <see cref="EmqNodesClientResult"/>
        /// </summary>
        v2_nodes_client,
        /// <summary>
        /// 获取集群内指定客户端的信息(带一个参数:客户端ID)
        /// <see cref="EmqNodesClientResult"/>
        /// </summary>
        v2_client,
        /// <summary>
        /// 获取指定节点的会话列表(带一个参数:节点名称,显示第几页,页面大小)
        /// </summary>
        v2_nodes_sessions,
        /// <summary>
        /// 获取节点上指定客户端的会话信息(带两个参数:节点名称,客户端ID)
        /// </summary>
        v2_nodes_session,
        /// <summary>
        /// 获取集群内指定客户端的会话信息(带一个参数:客户端id)
        /// </summary>
        v2_session,
        /// <summary>
        /// 获取某个节点上的订阅列表(带一个参数:节点名称,显示第几页,页面大小)
        /// </summary>
        v2_nodes_subscriptions,
        /// <summary>
        /// 获取节点上指定客户端的订阅信息(带两个参数:节点名称,客户端ID)
        /// </summary>
        v2_nodes_subscription,
        /// <summary>
        /// 获取集群内指定客户端的订阅信息(带一个参数:客户端ID)
        /// </summary>
        v2_subscription,
        /// <summary>
        /// 获取集群主题信息(参数空,显示第几页,页面大小)
        /// </summary>
        v2_routes,
        ///// <summary>
        ///// 获取集群内指定主题的信息(带一个参数:主题)
        ///// </summary>
        //v2_route,
        /// <summary>
        /// 获取节点的插件列表(带一个参数:节点名称)
        /// </summary>
        v2_nodes_plugins,
        ///// <summary>
        ///// 获取集群的监听器列表(参数空)
        ///// </summary>
        //v2_monitoring_listeners,
        /// <summary>
        /// 获取指定节点的监听器列表(带一个参数:节点名称)
        /// </summary>
        v2_monitoring_listener,
        /// <summary>
        /// 获取全部节点的度量指标(参数空)
        /// </summary>
        v2_monitoring_metrics,
        ///// <summary>
        ///// 获取指定节点的度量指标(带一个参数:节点名称)
        ///// </summary>
        //v2_monitoring_metric,
        /// <summary>
        /// 获取全部节点的运行统计(参数空)
        /// </summary>
        v2_monitoring_stats,
        ///// <summary>
        ///// 获取指定节点的运行统计(带一个参数:节点名称)
        ///// </summary>
        //v2_monitoring_stat
    }
}