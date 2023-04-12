﻿using MqttLibrary;
using MqttLibrary.Managed;
using MQTTnet;
using MQTTnet.Protocol;
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
            await Subscriber.SubscribeAsync(client, "home",MqttQualityOfServiceLevel.AtLeastOnce);
        };

        client.ApplicationMessageReceivedAsync += e =>
        {
            Console.WriteLine($"Nhận tin nhắn - {Encoding.UTF8.GetString(e.ApplicationMessage.Payload)}");
            return Task.CompletedTask;
        };

        client.DisconnectedAsync += e =>
        {
            Console.WriteLine("DisConnected to the broker successfully");
            return Task.CompletedTask;
        };

        await ClientBase.StartAsync(client, options);
        
        Console.ReadLine();
    }
}