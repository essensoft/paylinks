using System.Text.Json.Serialization;
using Essensoft.Paylinks.WeChatPay.Core;

namespace Essensoft.Paylinks.WeChatPay.Payments.Response;

public class WeChatPayTransactionsAppResponse : WeChatPayResponse
{
    /// <summary>
    /// 预支付交易会话标识。用于后续接口调用中使用，该值有效期为2小时
    /// </summary>
    [JsonPropertyName("prepay_id")]
    public string PrepayId { get; set; }
}
