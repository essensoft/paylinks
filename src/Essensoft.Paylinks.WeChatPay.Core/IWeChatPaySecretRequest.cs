namespace Essensoft.Paylinks.WeChatPay.Core;

/// <summary>
/// WeChatPay 敏感信息请求
/// </summary>
/// <typeparam name="T">应答</typeparam>
public interface IWeChatPaySecretRequest<T> : IWeChatPayRequest<T> where T : WeChatPayResponse;
