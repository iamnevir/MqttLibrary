using MqttLibrary;
using MQTTnet.Protocol;
using MqttLibrary.UnManaged;
using MqttLibrary.Rpc;
using System.Text;
using MQTTnet.Internal;
using System;

namespace NvPublisher;
class RpcTest
{
    static async Task Main()
    {
        var configManager = ConfigManager<Configuration>.Instance.Config;

        var options = ClientBase.CreateMqttClientOptions(configManager);

        var rpcOption = Extension.CreateRpcClientOption();

        var client = ClientBase.CreateMqttClient();

        await ClientBase.ConnectAsync(client, options);

        Console.WriteLine("Press any key");

        Console.ReadLine();

        using (var mqttRpcClient = Extension.CreateRpcClient(client, rpcOption))
        {
            client.ApplicationMessageReceivedAsync += e =>
            {
                Console.WriteLine($"Received Message - {Encoding.UTF8.GetString(e.ApplicationMessage.Payload)}");
                return Task.CompletedTask;
            };
            await RpcClient.ExecuteAsync(mqttRpcClient,TimeSpan.FromSeconds(2), "ping", "", MqttQualityOfServiceLevel.AtMostOnce);
        }

        Console.WriteLine("completed");

        Console.ReadLine();
    }


}
