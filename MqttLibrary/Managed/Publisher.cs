using MQTTnet.Client;
using MQTTnet;
using MQTTnet.Protocol;
using System.Text;
using MQTTnet.Extensions.ManagedClient;

namespace MqttLibrary.Managed;

public class Publisher
{
    public static async Task ManagedEnqueueAsync(IManagedMqttClient managedMqttClient, string topic, string payload, MqttQualityOfServiceLevel mqttQualityOfServiceLevel)
    {
        ClientBase.CheckConnected(managedMqttClient);
        var mqttApplicationMessage = new MqttApplicationMessageBuilder()
            .WithQualityOfServiceLevel(mqttQualityOfServiceLevel)
            .WithTopic(topic)
            .WithPayload(Encoding.UTF8.GetBytes(payload))
            .Build();
        var managedMqttApplicationMessage = new ManagedMqttApplicationMessage() { Id = Guid.NewGuid(), ApplicationMessage = mqttApplicationMessage };
        await managedMqttClient.EnqueueAsync(managedMqttApplicationMessage);
    }
    public static async Task EnqueueAsync(IManagedMqttClient managedMqttClient, string topic, string payload, MqttQualityOfServiceLevel mqttQualityOfServiceLevel)
    {
        ClientBase.CheckConnected(managedMqttClient);
        var mqttApplicationMessage = new MqttApplicationMessageBuilder()
            .WithQualityOfServiceLevel(mqttQualityOfServiceLevel)
            .WithTopic(topic)
            .WithPayload(Encoding.UTF8.GetBytes(payload))
            .Build();
        await managedMqttClient.EnqueueAsync(mqttApplicationMessage);
    }
}
