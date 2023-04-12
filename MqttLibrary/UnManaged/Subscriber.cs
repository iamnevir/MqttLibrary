using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Packets;

namespace MqttLibrary.UnManaged;

public class Subscriber
{
    public static async Task Subscribe_Topic(IMqttClient mqttClient, MqttTopicFilter topicFilter)
    {
        ClientBase.CheckConnected(mqttClient);
        await mqttClient.SubscribeAsync(topicFilter, CancellationToken.None);
    }
}

