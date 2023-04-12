using MqttLibrary;
using MqttLibrary.Configuration;
using MqttLibrary.UnManaged;
using MQTTnet;
using System.Text;

namespace NvSubscriber;
class NvSubscriber
{
    static async Task Main(string[] args)
    {
        var configManager = ConfigManager<Configuration>.Instance.Config;
        var options = ClientBase.OptionBuilder(configManager);
        var client = ClientBase.CreateAsync();
        client.ConnectedAsync += async e =>
        {
            Console.WriteLine("Connected to the broker successfully");
            var topicFilter = new MqttTopicFilterBuilder().WithTopic("Home/Temp").Build();
            await Subscriber.Subscribe_Topic(client, topicFilter);
        };

        client.ApplicationMessageReceivedAsync += e =>
        {
            Console.WriteLine($"Received Message - {Encoding.UTF8.GetString(e.ApplicationMessage.Payload)}");
            return Task.CompletedTask;
        };

        client.DisconnectedAsync += e =>
        {
            Console.WriteLine("DisConnected to the broker successfully");
            return Task.CompletedTask;
        };

        await ClientBase.ConnectClientAsync(client, options);
        
        Console.ReadLine();

        await ClientBase.DisconnectClientAsync(client);
    }
}