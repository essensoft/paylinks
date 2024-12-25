using Essensoft.Paylinks.WeChatPay.Core;

namespace Essensoft.Paylinks.WeChatPay.Client;

/// <summary>
/// WeChatPay 通知客户端
/// </summary>
public interface IWeChatPayNotifyClient
{
    /// <summary>
    /// 执行通知(验签并且序列化)
    /// </summary>
    /// <param name="headers">头部信息</param>
    /// <param name="body">内容</param>
    /// <param name="options">选项</param>
    /// <typeparam name="T">通知资源</typeparam>
    /// <returns>通知资源</returns>
    Task<T> ExecuteAsync<T>(WeChatPayHeaders headers, string body, WeChatPayClientOptions options) where T : IWeChatPayNotifyResource;
}
