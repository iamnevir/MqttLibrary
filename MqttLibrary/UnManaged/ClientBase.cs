using MQTTnet.Client;
using MQTTnet;
using MqttLibrary.Configuration;
using MQTTnet.Server;

namespace MqttLibrary.UnManaged;

public class ClientBase
{
    public static void CheckConnected(IMqttClient mqttClient)
    {
        if (!mqttClient.IsConnected)
            throw new Exception("Client does not connected!");
    }
    public static IMqttClient CreateAsync()
    {
        var mqttFactory = new MqttFactory();
        IMqttClient mqttClient = mqttFactory.CreateMqttClient();
        return mqttClient;
    }
    public static MqttClientOptions OptionBuilder(Configuration.Configuration configuration)
    {
        MqttClientOptions mqttClientOptions = new MqttClientOptionsBuilder().WithTcpServer(configuration.Sever, configuration.Port).WithCredentials(configuration.UserName,configuration.Password).Build();
        return mqttClientOptions;
    }
    public static async Task DisconnectClientAsync(IMqttClient mqttClient)
    {
        await mqttClient.DisconnectAsync(new MqttClientDisconnectOptionsBuilder().WithReason(MqttClientDisconnectReason.NormalDisconnection).Build());
    }
    public static async Task ConnectClientAsync(IMqttClient mqttClient, MqttClientOptions mqttClientOptions)
    {       
        await mqttClient.ConnectAsync(mqttClientOptions, CancellationToken.None);
    }
}

