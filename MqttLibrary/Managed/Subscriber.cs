using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Extensions.ManagedClient;
using MQTTnet.Packets;
using MQTTnet.Protocol;

namespace MqttLibrary.Managed;

public class Subscriber
{

    public static async Task SubscribeAsync(IManagedMqttClient managedMqttClient, string topic, MqttQualityOfServiceLevel mqttQualityOfServiceLevel)
    {
        ClientBase.CheckConnected(managedMqttClient);
        var topicFilter = new MqttTopicFilterBuilder().WithTopic(topic).WithQualityOfServiceLevel(mqttQualityOfServiceLevel).Build();
        ICollection<MqttTopicFilter> mqttTopicFilters = new List<MqttTopicFilter>
        {
            topicFilter
        };
        await managedMqttClient.SubscribeAsync(mqttTopicFilters);
    }
    public static async Task UnSubscribesAsync(IManagedMqttClient managedMqttClient, string topic)
    {
        ClientBase.CheckConnected(managedMqttClient);
        ICollection<string> topics = new List<string>
        {
            topic
        };
        await managedMqttClient.UnsubscribeAsync(topics);
    }
    public static async Task UnSubscribeAsync(IManagedMqttClient managedMqttClient, string topic)
    {
        ClientBase.CheckConnected(managedMqttClient);
        await managedMqttClient.UnsubscribeAsync(topic);
    }
}

