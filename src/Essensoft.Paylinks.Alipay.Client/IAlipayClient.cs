using Essensoft.Paylinks.Alipay.Core;

namespace Essensoft.Paylinks.Alipay.Client;

/// <summary>
/// Alipay 客户端
/// </summary>
public interface IAlipayClient
{
    /// <summary>
    /// 执行请求
    /// </summary>
    /// <param name="request">请求</param>
    /// <param name="options">选项</param>
    /// <param name="appAuthToken">应用授权令牌</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>应答</returns>
    Task<T> ExecuteAsync<T>(IAlipayRequest<T> request, AlipayClientOptions options, string? appAuthToken = null, CancellationToken cancellationToken = default) where T : AlipayResponse;

    /// <summary>
    /// 执行请求
    /// </summary>
    /// <param name="request">请求</param>
    /// <param name="options">选项</param>
    /// <param name="appAuthToken">应用授权令牌</param>
    /// <returns>应答</returns>
    Task<string> SdkExecuteAsync(IAlipaySdkRequest request, AlipayClientOptions options, string? appAuthToken = null);

    /// <summary>
    /// 执行请求
    /// </summary>
    /// <param name="request">请求</param>
    /// <param name="options">选项</param>
    /// <param name="appAuthToken">应用授权令牌</param>
    /// <param name="reqMethod">请求方法</param>
    /// <returns>应答</returns>
    Task<string> PageExecuteAsync(IAlipaySdkRequest request, AlipayClientOptions options, string? appAuthToken = null, string? reqMethod = null);
}
