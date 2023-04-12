using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Packets;
using MQTTnet.Protocol;

namespace MqttLibrary.UnManaged;

public class Subscriber
{

    public static async Task SubscribeAsync(IMqttClient mqttClient, string topic,MqttQualityOfServiceLevel mqttQualityOfServiceLevel)
    {
        ClientBase.CheckConnected(mqttClient);
        var topicFilter = new MqttTopicFilterBuilder().WithTopic(topic).WithQualityOfServiceLevel(mqttQualityOfServiceLevel).Build();
        await mqttClient.SubscribeAsync(topicFilter, CancellationToken.None);
    }
    public static async Task UnSubscribeAsync(IMqttClient mqttClient, string topic)
    {
        ClientBase.CheckConnected(mqttClient);
        await mqttClient.UnsubscribeAsync(topic, CancellationToken.None);
    }
}

