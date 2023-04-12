using MQTTnet.Client;
using MQTTnet;
using MqttLibrary.Configuration;
using MQTTnet.Server;

namespace MqttLibrary.UnManaged;

public class Publisher
{

    public static async Task PublishApplicationMessage(IMqttClient mqttClient, MqttApplicationMessage applicationMessage)
    {
        ClientBase.CheckConnected(mqttClient);
        await mqttClient.PublishAsync(applicationMessage, CancellationToken.None);
    }

}
