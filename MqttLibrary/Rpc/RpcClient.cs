using MQTTnet.Extensions.Rpc;
using MQTTnet.Protocol;
using System.Text;
using System.Threading;

namespace MqttLibrary.Rpc;

public class RpcClient
{
    public static async Task ExecuteAsync(IMqttRpcClient mqttRpcClient,TimeSpan timeout, string methodName, string payload, MqttQualityOfServiceLevel qualityOfServiceLevel)
    {
        var bytePlayLoad = Encoding.UTF8.GetBytes(payload);
        await mqttRpcClient.ExecuteAsync(timeout, methodName, bytePlayLoad, qualityOfServiceLevel);
    }
    public static async Task ExecuteAsync(IMqttRpcClient mqttRpcClient,string methodName, string payload, MqttQualityOfServiceLevel qualityOfServiceLevel, CancellationToken cancellationToken = default)
    {
        var bytePlayLoad = Encoding.UTF8.GetBytes(payload);
        await mqttRpcClient.ExecuteAsync(methodName, bytePlayLoad, qualityOfServiceLevel, cancellationToken).ConfigureAwait(false);
    }
}
