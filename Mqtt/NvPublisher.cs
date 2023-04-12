using MqttLibrary;
using MqttLibrary.Configuration;
using MqttLibrary.UnManaged;
using MQTTnet;

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

        
        await ClientBase.ConnectClientAsync(client, options);

        Console.WriteLine("nhap");
        Console.ReadLine();
        var applicationMessage = new MqttApplicationMessageBuilder().WithTopic("Home/Temp").WithPayload("vaicalonroi").Build();
        await Publisher.PublishApplicationMessage(client, applicationMessage);
        await ClientBase.DisconnectClientAsync(client);
        Console.ReadLine();
    }
}