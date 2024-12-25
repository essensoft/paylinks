using System.Text.Json.Serialization;
using Essensoft.Paylinks.WeChatPay.Core;

namespace Essensoft.Paylinks.WeChatPay.Payments.Response;

public class WeChatPayCombineH5PrepayResponse : WeChatPayResponse
{
    /// <summary>
    /// 支付跳转链接
    /// </summary>
    [JsonPropertyName("h5_url")]
    public string H5Url { get; set; }
}
