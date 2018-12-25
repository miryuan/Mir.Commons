/******************************************************************
* 项目名称 ：Mir.Commons.Mqtt 
* 项目描述 ： 
* 类 名 称 ：EmqEntitys 
* 类 描 述 ： 
* CLR 版本 ：4.0.30319.42000 
* 版权所有 ：袁振峰
* 联系方式 ：http://www.ustuy.com/ 
******************************************************************/
using System;
using System.Linq;
using System.Collections.Generic;
using Mir.Commons.Extensions;

namespace Mir.Commons.Mqtt
{
    /// <summary>
    /// 接口列表
    /// </summary>
    public class EmqAPIListResult : IV2Base
    {
        /// <summary>
        /// 列表
        /// </summary>
        public List<string> paths { get; set; }
    }

    #region management nodes
    /// <summary>
    /// 多节点Entity
    /// </summary>
    public class EmqManagementNodesResult
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Version { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Sysdescr { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Uptime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime Datetime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Otp_Release { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Node_Status { get; set; }
    }

    /// <summary>
    /// 单个节点Entity
    /// </summary>
    public class EmqManagementNodeResult
    {
        /// <summary>
        /// 
        /// </summary>
        public string Version { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Sysdescr { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Uptime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime Datetime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Otp_Release { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Node_Status { get; set; }
    }
    #endregion

    #region monitoring nodes
    /// <summary>
    /// 全部节点的监控数据Entity
    /// </summary>
    public class EmqMonitoringNodesResult
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Otp_Release { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Memory_Total { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Memory_Used { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long Process_Available { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long Process_Used { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long Max_Fds { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long Clients { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Node_Status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Load1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Load5 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Load15 { get; set; }
    }

    /// <summary>
    /// 单个节点的监控数据Entity
    /// </summary>
    public class EmqMonitoringNodeResult
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Otp_Release { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Memory_Total { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Memory_Used { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long Process_Available { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long Process_Used { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long Max_Fds { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long Clients { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Node_Status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Load1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Load5 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Load15 { get; set; }
    }
    #endregion

    #region monitoring listeners
    /// <summary>
    /// 
    /// </summary>
    public class EmqMonitoringListenerResult
    {
        /// <summary>
        /// 
        /// </summary>
        public string Protocol { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Listen { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Acceptors { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Max_Clients { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Current_Clients { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class EmqMonitoringListenersResult
    {
        /// <summary>
        /// 
        /// </summary>
        public string NodeName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public EmqMonitoringListenerResult[] Listeners { get; set; }
    }
    #endregion

    #region monitoring metrics
    /// <summary>
    /// 
    /// </summary>
    public class EmqMonitoringMetricsResult
    {
        /// <summary>
        /// 
        /// </summary>
        public EmqMonitoringMetricsResult()
        {
            Lis = new List<EmqMonitoringMetricEntity>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dics"></param>
        public EmqMonitoringMetricsResult(Dictionary<string, Dictionary<string, string>>[] dics)
        {
            Lis = new List<EmqMonitoringMetricEntity>();
            foreach (var dic in dics)
            {
                foreach (var di in dic)
                {
                    Lis.Add(new EmqMonitoringMetricEntity()
                    {
                        NodeName = di.Key,
                        Node = Chant(di.Value)
                    });
                }
            }
        }

        private MonitoringMetricEntity Chant(Dictionary<string, string> di)
        {
            return new MonitoringMetricEntity()
            {
                PacketsReceived = di.First(c => c.Key == "packets/received").Value.ToLong(0),
                BytesSent = di.First(c => c.Key == "bytes/sent").Value.ToLong(0),
                PacketsSubscribe = di.First(c => c.Key == "packets/subscribe").Value.ToInt(0),
                PacketsConnack = di.First(c => c.Key == "packets/connack").Value.ToInt(0),
                BytesReceived = di.First(c => c.Key == "bytes/received").Value.ToLong(0),
                MessagesQos1Sent = di.First(c => c.Key == "messages/qos1/sent").Value.ToInt(0),
                PacketsPubrelSent = di.First(c => c.Key == "packets/pubrel/sent").Value.ToInt(0),
                PacketsConnect = di.First(c => c.Key == "packets/connect").Value.ToInt(0),
                PacketsPubrelMissed = di.First(c => c.Key == "packets/pubrel/missed").Value.ToInt(0),
                PacketsPubrecSent = di.First(c => c.Key == "packets/pubrec/sent").Value.ToInt(0),
                Packetsunsuback = di.First(c => c.Key == "packets/unsuback").Value.ToInt(0),
                PacketsSent = di.First(c => c.Key == "packets/sent").Value.ToInt(0),
                messagesQos1Received = di.First(c => c.Key == "messages/qos1/received").Value.ToInt(0),
                PacketsPingresp = di.First(c => c.Key == "packets/pingresp").Value.ToInt(0),
                PacketsSuback = di.First(c => c.Key == "packets/suback").Value.ToInt(0),
                PacketsPubrelReceived = di.First(c => c.Key == "packets/pubrel/received").Value.ToInt(0),
                MessagesDropped = di.First(c => c.Key == "messages/dropped").Value.ToInt(0),
                MessagesSent = di.First(c => c.Key == "messages/sent").Value.ToInt(0),
                PacketsUnsubscribe = di.First(c => c.Key == "packets/unsubscribe").Value.ToInt(0),
                MessagesRetained = di.First(c => c.Key == "messages/retained").Value.ToInt(0),
                MessagesQos2Received = di.First(c => c.Key == "messages/qos2/received").Value.ToInt(0),
                MessagesQos0Received = di.First(c => c.Key == "messages/qos0/sent").Value.ToInt(0),
                PacketsPubrecReceived = di.First(c => c.Key == "packets/pubrec/received").Value.ToInt(0),
                PacketsPubrecMissed = di.First(c => c.Key == "packets/pubrec/missed").Value.ToInt(0),
                PacketsPubackReceived = di.First(c => c.Key == "packets/puback/received").Value.ToInt(0),
                PacketsPubackMissed = di.First(c => c.Key == "packets/puback/missed").Value.ToInt(0),
                MessagesQos2Sent = di.First(c => c.Key == "messages/qos2/sent").Value.ToInt(0),
                PacketsPubcompReceived = di.First(c => c.Key == "packets/pubcomp/received").Value.ToInt(0),
                PacketsPublishSent = di.First(c => c.Key == "packets/publish/sent").Value.ToInt(0),
                MessagesQos0Sent = di.First(c => c.Key == "messages/qos0/received").Value.ToInt(0),
                PacketsPubackSent = di.First(c => c.Key == "packets/puback/sent").Value.ToInt(0),
                PacketsPublishReceived = di.First(c => c.Key == "packets/publish/received").Value.ToInt(0),
                PacketsPingreq = di.First(c => c.Key == "packets/pingreq").Value.ToInt(0),
                PacketsPubcompMissed = di.First(c => c.Key == "packets/pubcomp/missed").Value.ToInt(0),
                PacketsDisconnect = di.First(c => c.Key == "packets/disconnect").Value.ToInt(0),
                MessagesReceived = di.First(c => c.Key == "messages/received").Value.ToInt(0),
                PacketsPubcompSent = di.First(c => c.Key == "packets/pubcomp/sent").Value.ToInt(0),
                MessagesQos2Dropped = di.First(c => c.Key == "messages/qos2/dropped").Value.ToInt(0)
            };
        }

        /// <summary>
        /// 
        /// </summary>
        public List<EmqMonitoringMetricEntity> Lis { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class EmqMonitoringMetricEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public string NodeName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public MonitoringMetricEntity Node { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class MonitoringMetricEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public long PacketsReceived { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long BytesSent { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PacketsSubscribe { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PacketsConnack { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long BytesReceived { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int MessagesQos1Sent { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int messagesQos1Received { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PacketsPubrelSent { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PacketsConnect { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PacketsPubrelMissed { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PacketsPubrecSent { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Packetsunsuback { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PacketsSent { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PessagesQos1Received { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PacketsPingresp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PacketsSuback { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PacketsPubrelReceived { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int MessagesDropped { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int MessagesSent { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PacketsUnsubscribe { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int MacketsUnsubscribe { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int MessagesRetained { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int MessagesQos2Received { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int MessagesQos0Sent { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PacketsPubrecReceived { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PacketsPubrecMissed { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PacketsPubackReceived { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PacketsPubackMissed { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int MessagesQos2Sent { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PacketsPubcompReceived { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PacketsPublishSent { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int MessagesQos0Received { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PacketsPubackSent { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PacketsPublishReceived { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PacketsPingreq { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PacketsPubcompMissed { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PacketsDisconnect { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int MessagesReceived { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PacketsPubcompSent { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int MessagesQos2Dropped { get; set; }
    }

    #endregion

    #region nodes clients
    /// <summary>
    /// 
    /// </summary>
    public class EmqNodesClientResult
    {
        /// <summary>
        /// 
        /// </summary>
        public List<EmqClientEntity> Objects { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class EmqNodesClientsResult
    {
        /// <summary>
        /// 
        /// </summary>
        public int Current_Page { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Page_Size { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Total_Num { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Total_Page { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<EmqClientEntity> Objects { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class EmqClientEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public string Client_Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string IpAddress { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Port { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool Clean_Sess { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Proto_Ver { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Keepalive { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime Connected_At { get; set; }
    }
    #endregion

    #region nodes plugins
    /// <summary>
    /// 
    /// </summary>
    public class EmqNodesPluginsResult
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Version { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool Active { get; set; }
    }
    #endregion

    #region nodes sessions
    /// <summary>
    /// 
    /// </summary>
    public class EmqNodesSessionsResult
    {
        /// <summary>
        /// 
        /// </summary>
        public int Current_Page { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Page_Size { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Total_Num { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Total_Page { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<EmqSessionEntity> Objects { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class EmqNodesSessionResult
    {
        /// <summary>
        /// 
        /// </summary>
        public List<EmqSessionEntity> Objects { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class EmqSessionEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public string Client_Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool Clean_Sess { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Subscriptions { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Max_Inflight { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Inflight_Len { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Mqueue_Len { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Mqueue_Dropped { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Awaiting_Rel_Len { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Deliver_Msg { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Enqueue_Msg { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime Created_At { get; set; }
    }
    #endregion

    #region nodes subscriptions
    /// <summary>
    /// 
    /// </summary>
    public class EmqNodesSubscriptionsResult
    {
        /// <summary>
        /// 
        /// </summary>
        public int Current_Page { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Page_Size { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Total_Num { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Total_Page { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<EmqSubscriptionEntity> Objects { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class EmqNodesSubscriptionResult
    {
        /// <summary>
        /// 
        /// </summary>
        public List<EmqSubscriptionEntity> Objects { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class EmqSubscriptionEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public string Client_Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Topic { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Qos { get; set; }
    }
    #endregion

    #region routes
    /// <summary>
    /// 
    /// </summary>
    public class EmqRoutesResult
    {
        /// <summary>
        /// 
        /// </summary>
        public int Current_Page { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Page_Size { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Total_Num { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Total_Page { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<EmqRouteEntity> Objects { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class EmqRouteEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public string Topic { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Node { get; set; }
    }
    #endregion

    #region clients
    /// <summary>
    /// 
    /// </summary>
    public class EmqMonitoringStatsResult
    {
        /// <summary>
        /// 
        /// </summary>
        public EmqMonitoringStatsResult()
        {
            Lis = new List<EmqMonitoringEntity>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dics"></param>
        public EmqMonitoringStatsResult(Dictionary<string, Dictionary<string, string>>[] dics)
        {
            Lis = new List<EmqMonitoringEntity>();
            foreach (var dic in dics)
            {
                foreach (var di in dic)
                {
                    Lis.Add(new EmqMonitoringEntity()
                    {
                        NodeName = di.Key,
                        Node = Chant(di.Value)
                    });
                }
            }
        }

        private EmqStatEntity Chant(Dictionary<string, string> di)
        {
            return new EmqStatEntity()
            {
                ClientsCount = di.First(c => c.Key == "clients/count").Value.ToInt(0),
                ClientsMax = di.First(c => c.Key == "clients/max").Value.ToInt(0),
                RetainedCount = di.First(c => c.Key == "retained/count").Value.ToInt(0),
                RetainedMax = di.First(c => c.Key == "retained/max").Value.ToInt(0),
                RoutesCount = di.First(c => c.Key == "routes/count").Value.ToInt(0),
                RoutesMax = di.First(c => c.Key == "routes/max").Value.ToInt(0),
                SessionsCount = di.First(c => c.Key == "sessions/count").Value.ToInt(0),
                SessionsMax = di.First(c => c.Key == "sessions/max").Value.ToInt(0),
                SubscribersCount = di.First(c => c.Key == "subscribers/count").Value.ToInt(0),
                SubscribersMax = di.First(c => c.Key == "subscribers/max").Value.ToInt(0),
                SubscriptionsCount = di.First(c => c.Key == "subscriptions/count").Value.ToInt(0),
                SubscriptionsMax = di.First(c => c.Key == "subscriptions/max").Value.ToInt(0),
                TopicsCount = di.First(c => c.Key == "topics/count").Value.ToInt(0),
                TopicsMax = di.First(c => c.Key == "topics/max").Value.ToInt(0)
            };
        }

        /// <summary>
        /// 
        /// </summary>
        public List<EmqMonitoringEntity> Lis { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class EmqMonitoringEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public string NodeName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public EmqStatEntity Node { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class EmqStatEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public int ClientsCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ClientsMax { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int RetainedCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int RetainedMax { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int RoutesCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int RoutesMax { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int SessionsCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int SessionsMax { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int SubscribersCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int SubscribersMax { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int SubscriptionsCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int SubscriptionsMax { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int TopicsCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int TopicsMax { get; set; }
    }
    #endregion
}
