using MQTTnet.Client;
using MQTTnet.Extensions.Rpc;
using MQTTnet.Protocol;

namespace MqttLibrary.Rpc;

public static class Extension
{
    public static async Task ExecuteAsync(this IMqttRpcClient client, TimeSpan timeout, string methodName, string payload, MqttQualityOfServiceLevel qualityOfServiceLevel)
    {
        await MqttRpcClientExtensions.ExecuteAsync(client, timeout, methodName, payload, qualityOfServiceLevel);
    }
    public static MqttRpcClientOptions CreateRpcClientOption()
    {
        IMqttRpcClientTopicGenerationStrategy topicGenerationStrategy = new DefaultMqttRpcClientTopicGenerationStrategy();
        MqttRpcClientOptions options = new MqttRpcClientOptionsBuilder()
            .WithTopicGenerationStrategy(topicGenerationStrategy)
            .Build();
        return options;
    }
    public static IMqttRpcClient CreateRpcClient(IMqttClient mqttClient, MqttRpcClientOptions options)
    {
        return new MqttRpcClient(mqttClient, options);
    }

}
