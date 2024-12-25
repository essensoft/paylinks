using Essensoft.Paylinks.WeChatPay.Core;

namespace Essensoft.Paylinks.WeChatPay.Client;

/// <summary>
/// WeChatPay 客户端
/// </summary>
public interface IWeChatPayClient
{
    /// <summary>
    /// 执行请求
    /// </summary>
    /// <param name="request">请求</param>
    /// <param name="options">选项</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>应答</returns>
    Task<T> ExecuteAsync<T>(IWeChatPayRequest<T> request, WeChatPayClientOptions options, CancellationToken cancellationToken = default) where T : WeChatPayResponse;

    /// <summary>
    /// 执行请求
    /// </summary>
    /// <param name="request">请求</param>
    /// <param name="options">选项</param>
    /// <returns>应答</returns>
    Task<T> SdkExecuteAsync<T>(IWeChatPaySdkRequest<T> request, WeChatPayClientOptions options) where T : WeChatPaySdkResponse;
}
