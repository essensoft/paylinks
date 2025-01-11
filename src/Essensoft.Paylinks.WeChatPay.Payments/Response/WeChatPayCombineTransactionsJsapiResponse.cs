using System.Text.Json.Serialization;
using Essensoft.Paylinks.WeChatPay.Core;

namespace Essensoft.Paylinks.WeChatPay.Payments.Response;

public class WeChatPayCombineTransactionsJsapiResponse : WeChatPayResponse
{
    /// <summary>
    /// 预支付交易会话标识。
    /// </summary>
    [JsonPropertyName("prepay_id")]
    public string PrepayId { get; set; }
}
