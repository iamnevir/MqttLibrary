
using MQTTnet.Client;

namespace MqttLibrary.Configuration;

/// <summary>
/// General configuration used across the protocol implementation
/// </summary>
public class Configuration
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MqttConfiguration" /> class 
    /// </summary>
    public Configuration()
    {
        Sever = "test.mosquitto.org";
        Port = 1883;
        UserName = "";
        Password = "";
        MaximumQualityOfService = MQTTnet.Protocol.MqttQualityOfServiceLevel.AtMostOnce;
    }
    public string Password { get; set; }
    public string UserName { get; set; }
    public string Sever { get; set; }
    /// <summary>
    /// Port to connect a Client to a Server
    /// </summary>
    public int Port { get; set; }

    /// <summary>
    /// Maximum Quality of Service (QoS) to support
    /// Default value is AtMostOnce, which means QoS 0
    /// </summary>
    public MQTTnet.Protocol.MqttQualityOfServiceLevel MaximumQualityOfService { get; set; }
}


