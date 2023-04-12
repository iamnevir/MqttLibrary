using MQTTnet.Client;
using MQTTnet;
using MQTTnet.Extensions.ManagedClient;

namespace MqttLibrary.Managed;

public class ClientBase
{
    public static void CheckConnected(IManagedMqttClient managedMqttClient)
    {
        if (!managedMqttClient.IsConnected)
            throw new Exception("Client does not connected!");
    }
    public static IManagedMqttClient CreateAsync()
    {
        var factory = new MqttFactory();
        IManagedMqttClient managedMqttClient = factory.CreateManagedMqttClient();
        return managedMqttClient;
    }
    public static ManagedMqttClientOptions OptionBuilder(MqttClientOptions mqttClientOptions,Configuration configuration)
    {
        ManagedMqttClientOptions managedMqttClientOptions = new ManagedMqttClientOptionsBuilder()
            .WithAutoReconnectDelay(TimeSpan.FromSeconds(5))
            .WithClientOptions(mqttClientOptions)
            .Build();
            
        return managedMqttClientOptions;
    }
    
    public static async Task StartAsync(IManagedMqttClient managedMqttClient, ManagedMqttClientOptions managedMqttClientOptions)
    {
        await managedMqttClient.StartAsync(managedMqttClientOptions);
    }
    public static async Task StopAsync(IManagedMqttClient managedMqttClient)
    {
        await managedMqttClient.StopAsync();
    }
    public static async Task PingAsync(IManagedMqttClient managedMqttClient)
    {
        await managedMqttClient.PingAsync(CancellationToken.None);
    }

}