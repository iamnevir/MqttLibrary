using MQTTnet.Client;
using MQTTnet;

namespace MqttLibrary.UnManaged;

public class ClientBase
{

    public static void CheckConnected(IMqttClient mqttClient)
    {
        if (!mqttClient.IsConnected)
            throw new Exception("Client does not connected!");
    }
    public static IMqttClient CreateMqttClient()
    {
        var factory = new MqttFactory();
        IMqttClient mqttClient = factory.CreateMqttClient();
        return mqttClient;
    }
    public static MqttClientOptions CreateMqttClientOptions(Configuration configuration)
    {
        MqttClientOptions mqttClientOptions = new MqttClientOptionsBuilder()
            .WithTcpServer(configuration.HostServer, configuration.Port)
            .WithCredentials(configuration.UserName, configuration.Password)
            .WithCleanSession()
            .WithClientId(Guid.NewGuid().ToString())
            .Build();
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
    public static async Task ReconnectAsync(IMqttClient mqttClient)
    {
        await mqttClient.ReconnectAsync(CancellationToken.None);
    }
    public static async Task TryPingAsync(IMqttClient mqttClient)
    {
        await mqttClient.TryPingAsync(CancellationToken.None);
    }
    public static async Task SendExtendedAuthenticationExchangeDataAsync(IMqttClient mqttClient, MqttExtendedAuthenticationExchangeData data)
    {
        await mqttClient.SendExtendedAuthenticationExchangeDataAsync(data,CancellationToken.None);
    }
}