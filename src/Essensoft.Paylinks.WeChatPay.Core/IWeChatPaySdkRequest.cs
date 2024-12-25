namespace Essensoft.Paylinks.WeChatPay.Core;

/// <summary>
/// WeChatPay SDK请求
/// </summary>
public interface IWeChatPaySdkRequest<T> where T : WeChatPaySdkResponse
{
    /// <summary>
    /// 签名处理器
    /// </summary>
    T SignatureHandler(string privateKey);
}
