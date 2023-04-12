using MQTTnet.Client;
using MQTTnet;
using MQTTnet.Server;
using MQTTnet.Protocol;
using System.Text;

namespace MqttLibrary.UnManaged;

public class Publisher
{
    public static async Task PublishAsync(IMqttClient mqttClient, string topic, string payload, MqttQualityOfServiceLevel mqttQualityOfServiceLevel)
    {
        ClientBase.CheckConnected(mqttClient);
        var mqttApplicationMessage = new MqttApplicationMessageBuilder()
            .WithQualityOfServiceLevel(mqttQualityOfServiceLevel)
            .WithTopic(topic)
            .WithPayload(Encoding.UTF8.GetBytes(payload))
            .Build();
        await mqttClient.PublishAsync(mqttApplicationMessage, CancellationToken.None);
    }
}
