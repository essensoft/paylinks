using System.Text.Json.Serialization;
using Essensoft.Paylinks.WeChatPay.Core;
using Essensoft.Paylinks.WeChatPay.Payments.Domain;

namespace Essensoft.Paylinks.WeChatPay.Payments.Response;

public class WeChatPayCombineAppPrepayResponse : WeChatPayResponse
{
    /// <summary>
    /// 预支付交易会话标识
    /// </summary>
    [JsonPropertyName("prepay_id")]
    public string PrepayId { get; set; }

    /// <summary>
    /// 预签约结果
    /// </summary>
    [JsonPropertyName("contract_result")]
    public ContractResult? ContractResult { get; set; }
}
