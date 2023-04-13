using MqttLibrary;
using MqttLibrary.Managed;
using MQTTnet.Protocol;
using System.Text;

namespace NvSubscriber;
class NvSubscriber
{
    static async Task Main()
    {
        var configManager = ConfigManager<Configuration>.Instance.Config;

        var options = ClientBase.CreateMqttClientOptions(configManager);

        var client = ClientBase.CreateMqttClient();

        client.ConnectedAsync += async e =>
        {
            await Subscriber.SubscribeAsync(client,"home",MqttQualityOfServiceLevel.AtLeastOnce);
        };

        client.ApplicationMessageReceivedAsync += e =>
        {
            Console.WriteLine($"Received Message - {Encoding.UTF8.GetString(e.ApplicationMessage.Payload)}");
            return Task.CompletedTask;
        };

        await ClientBase.StartAsync(client, options);

        Console.ReadLine();
    }
}