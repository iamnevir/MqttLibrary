using MqttLibrary;
using MqttLibrary.Managed;
using MQTTnet;
using MQTTnet.Protocol;

namespace NvPublisher;
class NvPublisher
{
    static async Task Main(string[] args)
    {
        var configManager = ConfigManager<Configuration>.Instance.Config;

        var options = ClientBase.OptionBuilder(configManager);

        var client = ClientBase.CreateAsync();

        client.ConnectedAsync += e => {
            if (client.IsConnected)
            {
                Console.WriteLine("Connected to the broker successfully");
            }
             return Task.CompletedTask; };
        client.DisconnectedAsync += e => { Console.WriteLine("DisConnected to the broker successfully"); return Task.CompletedTask; };

        await ClientBase.StartAsync(client, options);

        Console.WriteLine("nhap");
        Console.ReadLine();

        await Publisher.EnqueueAsync(client,"home","helo",MqttQualityOfServiceLevel.AtLeastOnce);

        Console.ReadLine();
    }
}