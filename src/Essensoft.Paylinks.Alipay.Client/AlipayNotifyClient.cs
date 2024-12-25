using System.Text.Json;
using Essensoft.Paylinks.Alipay.Core;

namespace Essensoft.Paylinks.Alipay.Client;

/// <summary>
/// Alipay 通知客户端
/// </summary>
public class AlipayNotifyClient : IAlipayNotifyClient
{
    public Task<T> ExecuteAsync<T>(IDictionary<string, string> parameters, AlipayClientOptions options) where T : IAlipayNotify
    {
        AlipaySignature.VerifySignatureV1(parameters, options.AlipayPublicKey);

        var bytes = JsonSerializer.SerializeToUtf8Bytes(parameters, AlipayJsonSerializerOptions.Default);
        var notify = JsonSerializer.Deserialize<T>(bytes, AlipayJsonSerializerOptions.Default);
        return Task.FromResult(notify!);
    }
}
