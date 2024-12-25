using Essensoft.Paylinks.Alipay.Core;

namespace Essensoft.Paylinks.Alipay.Client;

/// <summary>
/// Alipay 通知客户端
/// </summary>
public interface IAlipayNotifyClient
{
    /// <summary>
    /// 执行通知(验签并且序列化)
    /// </summary>
    /// <param name="parameters">参数</param>
    /// <param name="options">选项</param>
    /// <returns>通知</returns>
    Task<T> ExecuteAsync<T>(IDictionary<string, string> parameters, AlipayClientOptions options) where T : IAlipayNotify;
}
