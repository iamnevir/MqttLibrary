using MqttLibrary;
using MQTTnet.Protocol;
using MqttLibrary.Managed;

namespace NvPublisher;
class NvPublisher
{
    static async Task Main()
    {
        var configManager = ConfigManager<Configuration>.Instance.Config;

        var options = ClientBase.CreateMqttClientOptions(configManager);

        var client = ClientBase.CreateMqttClient();

        await ClientBase.StartAsync(client, options);

        Console.WriteLine("Press enter to publish");

        Console.ReadLine();

        await Publisher.EnqueueAsync(client, "home", "helo world", MqttQualityOfServiceLevel.AtLeastOnce);

        Console.ReadLine();
    }
}